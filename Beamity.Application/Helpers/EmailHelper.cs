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
                //Text = "<!doctype html><html lang='en'> <head> <!-- Required meta tags --> <meta charset='utf-8'> <meta name='viewport' content='width=device-width, initial-scale=1, shrink-to-fit=no'> <!-- Bootstrap CSS --> <link rel='stylesheet' href='https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css' integrity='sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T' crossorigin='anonymous'> </head> <body> <div class='container p-5 text-white' style='background-color:#212529'> <div class='text-center'> <img src='https://testblobkayten.blob.core.windows.net/blobcontainer/c627e3fc9c034c9a9ff729f9ddf2893a.png' style='width:300px' alt=''> <h4>Beamity CMS Application</h4> <br> <h5>Please click the link for confirm your account !</h5> <a href='https://localhost:4001/confirmation/verification/?guidcode=' + guidkey + '' class='btn btn-secondary'>Confirm Link</a> </div> </div> <!-- Optional JavaScript --> <!-- jQuery first, then Popper.js, then Bootstrap JS --> <script src='https://code.jquery.com/jquery-3.3.1.slim.min.js' integrity='sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo' crossorigin='anonymous'></script> <script src='https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js' integrity='sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1' crossorigin='anonymous'></script> <script src='https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js' integrity='sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM' crossorigin='anonymous'></script> </body></html>"
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
