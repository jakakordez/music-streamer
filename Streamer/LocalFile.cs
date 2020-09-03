using SharpCifs.Util.Sharpen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TagLib;

namespace Streamer
{
    public class LocalFile : MusicFile
    {
        LocalSource source;
        TagLib.File tfile;

        public LocalFile(LocalSource source, string filename)
        {
            var parts = filename.Split('\\');
            Filename = parts.Last();
            this.source = source;
            tfile = TagLib.File.Create(filename);
            Title = tfile.Tag.Title;
            Artist = tfile.Tag.FirstPerformer;
        }

        public override MemoryStream Read()
        {
            return source.Read(this);
        }
    }
}
