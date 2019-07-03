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
            message.Subject = "Hesap Doğrulama"; // This are for the subject
            message.Body = new TextPart("html")
            {
                // This are for the content
                Text = "Hesabınızı onaylamak için aşağıdaki linke tıklayınız... <br/>" +
                "<a href='https://nootelib.com/Confirmation/Verification/?guidcode=" + guidkey + "'>Onaylama Linki<a/>"
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
