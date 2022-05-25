using System.Net;
using System.Net.Mail;

namespace ChitalkaMVC
{
    public static class EMailService
    {
        public static void SendEmail(string receiver, int verificationCode, string subject)
        {
            try
            {
                MailMessage message = new();
                message.From = new MailAddress("susysugoma@gmail.com", "Chitalka Verification");
                message.To.Add(receiver);
                message.Subject = subject;
                message.Body = "Your verification code is: " + verificationCode.ToString();

                using (SmtpClient client = new("smtp.gmail.com"))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("susysugoma@gmail.com", "nQ8-n5E-rN2-329");
                    client.Port = 587;
                    client.EnableSsl = true;

                    client.Send(message);
                }

            }
            catch (Exception e)
            {

            }
        }
    }
}
