using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TagLib;

namespace Music_streamer
{
    class MusicFile
    {
        Mp3FileReader reader;

        public string Filename;
        private File tfile;
        long duration;
        Stopwatch stw;

        public MusicFile(string filename)
        {
            Filename = filename;

            tfile = File.Create(filename);
            //tfile.Properties.Duration
        }

        public string Title => tfile.Tag.Title;
        public string Artist => tfile.Tag.FirstPerformer;

        public void Open()
        {
            stw = new Stopwatch();
            reader = new Mp3FileReader(Filename);
            duration = 0;
            stw.Start();
        }

        public Mp3Frame GetFrame()
        {
            while(stw.ElapsedMilliseconds < duration)
            {
                Thread.Sleep(1);
            }
            var frame = reader.ReadNextFrame();
            duration += FrameDuration(frame);
            return frame;
        }

        private static long FrameDuration(Mp3Frame frame)
        {
            var byterate = frame.BitRate / 8;
            return frame.FrameLength * 1000 / byterate;
        }

        public override string ToString()
        {
            if (Title != null && Title != "") return Title;
            var res = new Regex(@"/|\\(.*)\.mp3").Match(Filename);
            return res.Captures[0].Value;
        }
    }
}
