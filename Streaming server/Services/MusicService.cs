using Streamer;
using Streaming_server.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;

namespace Streaming_server.Services
{
    public class MusicService
    {
        MusicCollection collection = new MusicCollection();
        MusicPlayer Player;        

        public MusicService()
        {
            Player = new MusicPlayer();
            Player.Start();
        }

        public List<ISource> GetSources()
        {
            return collection.GetSources();
        }

        public void AddSource(ISource source)
        {
            collection.AddSource(source);
        }

        public List<MusicFile> ListFiles()
        {
            return collection.ListFiles();
        }

        public MemoryStream DownloadFile(Guid id)
        {
            return collection.DownloadFile(id);
        }

        public void PlayFile(Guid id)
        {
            Player.EnqueueMusic(collection.GetFile(id));
        }

        public void ServeClient(BinaryWriter sw)
        {
            var token = Player.Attach(sw);
            while (!token.IsCancellationRequested) System.Threading.Thread.Sleep(1);
        }
    }
}
