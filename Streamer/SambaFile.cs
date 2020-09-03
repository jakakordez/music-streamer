using SharpCifs.Smb;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Streamer
{
    public class SambaFile : MusicFile
    {
        SambaSource Source;
        SmbFile file;

        public SambaFile(SmbFile file, SambaSource source)
        {
            Filename = file.GetName();
            Source = source;
            this.file = file;
        }

        public override MemoryStream Read()
        {
            var readStream = file.GetInputStream();
            var memStream = new MemoryStream();
            ((Stream)readStream).CopyTo(memStream);
            readStream.Dispose();
            memStream.Seek(0, SeekOrigin.Begin);
            return memStream;
        }
    }
}
