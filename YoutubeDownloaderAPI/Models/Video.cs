using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YoutubeExplode;

namespace YoutubeDownloaderAPI.Models
{
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Duration { get; set; }
        public IReadOnlyList<YoutubeExplode.Common.Thumbnail> Thumbnails { get; set; }
    }
}
