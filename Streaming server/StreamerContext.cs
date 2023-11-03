using Microsoft.EntityFrameworkCore;
using Streamer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Streaming_server
{
    public class StreamerContext:DbContext
    {
        public StreamerContext(DbContextOptions<StreamerContext> options) : base(options)
        {
        }

        public DbSet<ISource> Sources { get; set; }
    }
}
