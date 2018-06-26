using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crossplatform_ssp
{
    public class Emailclass
    {

        public static void getemail(String email, string navn, string efternavn)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var numbers = "0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < 2; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            for (int i = 2; i < 6; i++)
            {
                stringChars[i] = numbers[random.Next(numbers.Length)];
            }
            for (int i = 6; i < 8; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);




            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Godkendelse", "ssp_helsingor@hotmail.com"));
            message.To.Add(new MailboxAddress(navn, email));
            message.Subject = "Godkendelseskode";

            message.Body = new TextPart("plain")
            {
                Text = navn + "<br>" + efternavn + "<br>" + email + "<br>" + "Godkendelseskode:" + finalString
            };

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.friends.com", 587, false);

                client.Authenticate("ssp_helsingor@hotmail.com", "helsingor123");

                client.Send(message);
                client.Disconnect(true);
            }

        }
    }
}
