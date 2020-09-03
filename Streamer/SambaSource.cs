using SharpCifs.Smb;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Streamer
{
    public class SambaSource : Source<SambaFile>
    {
        string Path;

        List<SambaFile> files;

        public SambaSource(string name, string path)
        {
            Name = name;
            Path = path;

            files = new SmbFile(Path)
                .ListFiles()
                .Where(f => f.IsFile() && f.GetName().EndsWith(".mp3"))
                .Select(f => new SambaFile(f, this))
                .ToList();
        }

        public override IEnumerable<MusicFile> ListFiles()
        {
            return files;
        }

        public override MemoryStream Read(SambaFile file)
        {
            return file.Read();
        }
    }
}
