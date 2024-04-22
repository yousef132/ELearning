using System.Net;
using System.Net.Mail;

namespace E_Commerce.Helper
{
    public static class EmailSettings
    {

        public static void SendEmail(Email email)
        {
            var cleint = new SmtpClient("smtp.gmail.com", 587);

            cleint.EnableSsl = true;
            cleint.Credentials = new NetworkCredential("saady8454@gmail.com", "ddefpvfypvewgcgn");

            cleint.Send("saady8454@gmail.com", email.To, email.Header, email.Body);

        }
    }
}
