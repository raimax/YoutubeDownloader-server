using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YoutubeDownloaderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudioDownloadController : ControllerBase
    {
        private readonly YoutubeClient _youtube;

        public AudioDownloadController()
        {
            _youtube = new YoutubeClient();
        }
        
        [HttpGet("{videoId}")]
        public async Task<IActionResult> Download(string videoId)
        {
            if (videoId == null)
            {
                return BadRequest("Video link not provided");
            }

            try
            {
                var streamManifest = await _youtube.Videos.Streams.GetManifestAsync(videoId.Trim());

                var streamInfo = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

                var ytVideo = await _youtube.Videos.GetAsync("https://youtube.com/watch?v=" + videoId);

                var stream = await _youtube.Videos.Streams.GetAsync(streamInfo);

                return File(stream, "application/octet-stream", $"{ytVideo.Title}.mp3");
            }
            catch (ArgumentException)
            {
                return NotFound(new { message = "Video doesn't exist" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
