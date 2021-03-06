using MailKit.Net.Smtp;
using MimeKit;

namespace Monitor
{
    public static class Mail
    {
        public static async Task SendMessage(string email)
        {
            MimeMessage message  = new MimeMessage();
            message.From.Add(new MailboxAddress("Cecelia", "ceceliajohnson777@gmail.com"));

            message.To.Add(MailboxAddress.Parse(email));

            message.Subject = "Testing";

            message.Body = new TextPart("plain")
            {
                Text = "My amazing email has been sent"
            };

            SmtpClient smtpClient = new SmtpClient();

            try
            {
                smtpClient.Connect("smtp.gmail.com", 465, true);
                smtpClient.Authenticate("ceceliajohnson777@gmail.com", "Ain3:_AiEm4HccC");
                await smtpClient.SendAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Mail could't be sent");
            }
            finally
            {
                smtpClient.Disconnect(true);
                smtpClient.Dispose();
            }
        }
    }
}
