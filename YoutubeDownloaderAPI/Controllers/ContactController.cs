using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using YoutubeDownloaderAPI.Models;

namespace YoutubeDownloaderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly Contact _contact;

        public ContactController()
        {
            _contact = new Contact();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(Contact contact)
        {
            _contact.Name = contact.Name;
            _contact.Message = contact.Message;

            if (String.IsNullOrWhiteSpace(contact.Email))
            {
                _contact.Email = "None";
            }
            else
            {
                _contact.Email = contact.Email;
            }

            Mail mail = new Mail(_contact.Name, _contact.Email, _contact.Message);

            try
            {
                await mail.SendMail();
                return Ok(new { message = "Message sent successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
