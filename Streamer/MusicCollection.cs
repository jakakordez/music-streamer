using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Streamer
{
    public class MusicCollection
    {
        List<ISource> sources = new List<ISource>();
        Dictionary<Guid, MusicFile> files = new Dictionary<Guid, MusicFile>();

        public List<ISource> GetSources()
        {
            return sources.ToList();
        }

        public void AddSource(ISource source)
        {
            sources.Add(source);
            foreach (var file in source.ListFiles())
            {
                files[file.Id] = file;
            }
        }

        public List<MusicFile> ListFiles()
        {
            return files.Values.ToList();
        }

        public MemoryStream DownloadFile(Guid id)
        {
            return files[id].Read();
        }

        public MusicFile GetFile(Guid id)
        {
            return files[id];
        }
    }
}
