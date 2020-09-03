using NAudio.Wave;
using NLayer.NAudioSupport;
using SharpCifs.Dcerpc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace Streamer
{
    public abstract class MusicFile
    {
        
        public string Filename { get; protected set; }
        public Guid Id { get; private set; }
        public string Artist { get; protected set; }
        public string Title { get; protected set; }

        Mp3FileReader reader;
        long duration;
        Stopwatch stw;

        public MusicFile()
        {
            Id = Guid.NewGuid();
        }

        public abstract MemoryStream Read();

        public void Open()
        {
            stw = new Stopwatch();
            var builder = new Mp3FileReader.FrameDecompressorBuilder(wf => new Mp3FrameDecompressor(wf));
            reader = new Mp3FileReader(Read(), builder);
            //reader = new Mp3FileReader(Read());
            duration = 0;
            stw.Start();
        }

        public void Close()
        {
            reader.Close();
            reader.Dispose();
        }

        public Mp3Frame GetFrame()
        {
            while (stw.ElapsedMilliseconds < duration)
            {
                Thread.Sleep(1);
            }
            var frame = reader.ReadNextFrame();
            if (frame == null) return frame;
            duration += FrameDuration(frame);
            return frame;
        }

        private static long FrameDuration(Mp3Frame frame)
        {
            var byterate = frame.BitRate / 8;
            return frame.FrameLength * 1000 / byterate;
        }
    }
}
