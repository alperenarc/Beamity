using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.Helpers
{
    public class EmailHelper
    {
        public static void SendMail(string email, string guidkey)
        {

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("beamity@nootelib.com")); // This are for from mail
            message.To.Add(new MailboxAddress(email)); // This are for to mail
            message.Subject = "Confirm Your Email"; // This are for the subject
            message.Body = new TextPart("html")
            {
                
                // This are for the content
                Text = "Beamity CMS Application<br/>Please click the link for confirm your account ! <br/>" +
                "<a href='https://localhost:4001/confirmation/verification/?guidcode=" + guidkey + "'>Confirm Link<a/>"
                //Confirmation / Verification /

            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("srvm04.turhost.com", 587, false); // You must write your host information on this area
                client.Authenticate("beamity@nootelib.com", "Qwerty123"); // You must write your server email and password
                client.Send(message);
                client.Disconnect(true);
            };


        }
    }
}
