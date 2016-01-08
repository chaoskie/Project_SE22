using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace GUI_Handler
{
    public class EmailHandler
    {
        /// <summary>
        /// Contains the basic information of a mail message header
        /// </summary>
        private static MailMessage mail = new MailMessage()
        {
            From = new MailAddress("no-reply@tronpon.com")
        };
        /// <summary>
        /// Contains the basic information of the smtp which is used to send the mail from
        /// </summary>
        private static SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new System.Net.NetworkCredential("tronponweb@gmail.com", "Tronpon!23"),
            EnableSsl = true
        };

        /// <summary>
        /// Contains the standard email and message
        /// </summary>
        private const string emailEnd =
                "\nVoor vragen en contact kunt u het volgende emailadres mailen: tronponweb@gmail.com"
                + "\n"
                + "\nMet vriendelijke groet,"
                + "\nTronpon, de nummer 1 image database";

        /// <summary>
        /// Sends a mail regarding a registration
        /// </summary>
        /// <param name="email">email to send to</param>
        /// <param name="username">username of the user</param>
        public static void SendRegistration(string email, string username)
        {
            mail.To.Clear();
            mail.To.Add(email);
            mail.Subject = "U hebt een account geregistreerd voor Tronpon";
            mail.Body = "Hallo!"
                + "\nU kunt nu inloggen door middel van uw account:"
                + "\n" + username + emailEnd;
            FinalSend();
        }

        /// <summary>
        /// Finalises and sends the mail
        /// </summary>
        private static void FinalSend()
        {
            SmtpServer.Send(mail);
        }
    }
}
