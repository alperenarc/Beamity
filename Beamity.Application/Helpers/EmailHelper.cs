using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.Helpers
{
    public class EmailHelper
    {
        public static void SendMail()
        {

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("info@nootelib.com")); // This are for from mail
            message.To.Add(new MailboxAddress("alp@gmail.com")); // This are for to mail
            message.Subject = "Email Onaylama"; // This are for the subject
            message.Body = new TextPart("html")
            {
                // This are for the content
            };
            

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("srvm04.turhost.com", 587, false); // You must write your host information on this area
                client.Authenticate("info@nootelib.com", "Qwerty123"); // You must write your server email and password
                client.Send(message);
                client.Disconnect(true);
            };


        }
    }
}
