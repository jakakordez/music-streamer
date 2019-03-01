using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TagLib;

namespace Music_streamer
{
    class MusicFile
    {
        Mp3FileReader reader;

        public string Filename;
        private File tfile;

        public MusicFile(string filename)
        {
            Filename = filename;

            tfile = File.Create(filename);
        }

        public string Title => tfile.Tag.Title;
        public string Artist => tfile.Tag.FirstPerformer;

        public void Open()
        {
            reader = new Mp3FileReader(Filename);
        }

        public Mp3Frame GetFrame()
        {
            return reader.ReadNextFrame();
        }

        public override string ToString()
        {
            if (Title != null && Title != "") return Title;
            var res = new Regex(@"/|\\(.*)\.mp3").Match(Filename);
            return res.Captures[0].Value;
        }
    }
}
