using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeDownloaderAPI.Models;

namespace YoutubeDownloaderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoInfoController : ControllerBase
    {
        private readonly YoutubeClient _youtube;
        private readonly Video _video;

        public VideoInfoController()
        {
            _youtube = new YoutubeClient();
            _video = new Video();
        }

        [HttpGet("{videoId}")]
        public async Task<IActionResult> GetInfo(string videoId)
        {
            if (videoId == null)
            {
                return BadRequest(new { message = "Video link not provided" });
            }

            try
            {
                var ytVideo = await _youtube.Videos.GetAsync("https://youtube.com/watch?v=" + videoId);

                _video.Title = ytVideo.Title;
                _video.Author = ytVideo.Author.Title;
                _video.Duration = ytVideo.Duration.ToString();
                _video.Thumbnails = ytVideo.Thumbnails;

                return Ok(_video);
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
