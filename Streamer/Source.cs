using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Streamer
{
    public interface ISource
    {
        string Name { get; }
        IEnumerable<MusicFile> ListFiles();
    }

    public abstract class Source<T>:ISource where T:MusicFile
    {
        public string Name { get; set; }

        public abstract IEnumerable<MusicFile> ListFiles();

        public abstract MemoryStream Read(T file);

    }
}
