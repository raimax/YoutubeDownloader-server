using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace YoutubeDownloaderAPI.Models
{
    public class Mail
    {
        private string From { get; set; } = "ytdl.server@gmail.com";
        private string To { get; set; } = "4miner44@gmail.com";
        private string ServerMailPassword { get; set; } = "S4Au5[*S)3'&_u&?";
        public string Body { get; set; }
        public string SenderName { get; set; }
        public string SenderEmail { get; set; }

        public Mail(string name, string email, string body)
        {
            SenderName = name;
            SenderEmail = email;
            Body = body;
        }

        public async Task SendMail()
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(To);
            mail.From = new MailAddress(From);
            mail.Subject = "New message from server " + DateTime.Now.ToString();
            mail.Body = $"Name: {SenderName}<br> Email: {SenderEmail}<br><br> {Body}";
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential(From, ServerMailPassword);
            smtp.EnableSsl = true;

            await smtp.SendMailAsync(mail);
        }
    }
}
