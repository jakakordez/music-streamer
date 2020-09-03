using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Streamer
{
    public class LocalSource:Source<LocalFile>
    {
        string Path;
        List<LocalFile> files;

        public LocalSource(string name, string path)
        {
            Name = name;
            Path = path;

            files = Directory
                .GetFiles(Path, "*.mp3")
                .Select(f => new LocalFile(this, f))
                .ToList();
        }

        public override IEnumerable<MusicFile> ListFiles()
        {
            return files;
        }

        public override MemoryStream Read(LocalFile file)
        {
            var fs = File.OpenRead(Path + "/" + file.Filename);
            MemoryStream s = new MemoryStream();
            fs.CopyTo(s);
            fs.Close();
            s.Seek(0, SeekOrigin.Begin);
            return s;
        }
    }
}
