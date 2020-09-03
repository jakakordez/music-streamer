using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Streamer
{
    public class MusicStreamer
    {
        public MusicPlayer Player;

        public MusicStreamer(int port)
        {
            Player = new MusicPlayer();
            Player.Start();

            var listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:" + port + "/");
            listener.Start();
            Task.Run(()=>{
                while (true)
                {
                    ThreadPool.QueueUserWorkItem(Process, listener.GetContext());
                }
            });
        }

        void Process(object o)
        {
            var context = o as HttpListenerContext;
            HttpListenerRequest req = context.Request;
            HttpListenerResponse res = context.Response;

            if (req.RawUrl != "/stream")
            {
                string responseString = "<HTML><BODY> Stream is available at /stream </BODY></HTML>";
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                res.ContentLength64 = buffer.Length;
                res.OutputStream.Write(buffer, 0, buffer.Length);
            }
            else
            {
                res.AddHeader("content-type", "audio/mpeg");
                Player.Attach(res.OutputStream);
                while (true) ;
            }

            res.OutputStream.Close();
        }
    }
}
