using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NAudio.Wave;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.Threading;

namespace Music_streamer
{
    class MusicPlayer
    {
        public struct MusicPlayerStatus
        {
            public MusicFile CurrentFile;
            public int Connections;
            public List<MusicFile> Queue;
        }

        public event Func<MusicPlayerStatus, object> OnStatusUpdate;
        public event Func<List<MusicFile>, object> OnFileListUpdate;

        ConcurrentQueue<MusicFile> queue = new ConcurrentQueue<MusicFile>();
        Thread playerThread;
        ConcurrentDictionary<Stream, DateTime> outputStreams;

        public void Start()
        {
            outputStreams = new ConcurrentDictionary<Stream, DateTime>();
            playerThread = new Thread(new ThreadStart(PlayerThread));
            playerThread.Start();
        }

        public bool Pause = false;

        public void EnqueueMusic(MusicFile file)
        {
            queue.Enqueue(file);
            if (OnFileListUpdate != null) OnFileListUpdate.Invoke(queue.ToList());
        }

        public void Attach(Stream outputStream)
        {
            outputStreams.TryAdd(outputStream, DateTime.Now);
        }

        public void Disattach(Stream outputStream)
        {
            outputStreams.TryRemove(outputStream, out DateTime value);
        }

        void PlayerThread()
        {
            MusicFile file = null;
            while (true)
            {
                do
                {
                    queue.TryDequeue(out file);
                    Thread.Sleep(2);
                } while (file == null);
                if (OnFileListUpdate != null) OnFileListUpdate.Invoke(queue.ToList());
                file.Open();
                Mp3Frame frame = file.GetFrame();
                while (frame != null)
                {
                    foreach (Stream output in outputStreams.Keys)
                    {
                        try
                        {
                            output.Write(frame.RawData, 0, frame.RawData.Length);
                            output.Flush();
                        }
                        catch
                        {
                            output.Close();
                            Disattach(output);
                        }
                    }
                    
                    frame = file.GetFrame();

                    if (OnStatusUpdate != null)
                    {
                        OnStatusUpdate.Invoke(new MusicPlayerStatus()
                        {
                            CurrentFile = file,
                            Connections = outputStreams.Count,
                            Queue = queue.ToList()
                        });
                    }

                    while (Pause)
                    {
                        Thread.Sleep(2);
                    }
                }
            }
        }
    }
}
