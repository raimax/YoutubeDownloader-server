using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YoutubeDownloaderAPI.Models
{
    public class Contact
    {
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
