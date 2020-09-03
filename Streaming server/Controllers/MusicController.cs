using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Streamer;
using Streaming_server.Services;

namespace Streaming_server.Controllers
{
    [ApiController]
    [Route("music")]
    public class MusicController:Controller
    {
        private readonly ILogger<MusicController> _logger;
        MusicService service;
        public MusicController(MusicService service, ILogger<MusicController> logger)
        {
            this.service = service;
            _logger = logger;
        }

        [HttpGet("/sources")]
        public object GetSources()
        {
            return service.GetSources();
        }

        [HttpGet("/files")]
        public IEnumerable<MusicFile> GetFiles()
        {
            return service.ListFiles();
        }

        [HttpGet("/play/{id}")]
        public IActionResult Play(string id)
        {
            service.PlayFile(new Guid(id));
            return Ok();
        }

        [HttpGet("/files/{id}")]
        public IActionResult GetFile(string id)
        {
            var guid = new Guid(id);
            var stream = service.DownloadFile(guid);
            return File(stream, "audio/mpeg");
        }

        [HttpGet("/stream")]
        public IActionResult GetStream()
        {
            _logger.LogInformation("New client connected from IP " + Request.HttpContext.Connection.RemoteIpAddress);
            Response.StatusCode = 200;
            Response.ContentType = "audio/mpeg";
            service.ServeClient(new BinaryWriter(Response.Body));
            return NoContent();
        }
    }
}
