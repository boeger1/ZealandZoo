using System.Net.Mail;
using ZealandZooLIB.Models;
using ZealandZooLIB.NewsletterHtml;

namespace ZealandZooLIB.Services
{
    public class SimplyMailService
    {
        public void SendSubscribedLetter(string email)
        {
            try
            {
                using var mailClient = Secrets.Secret.GetMailClient();

                var welcomeLetter = new SubscribedNewsletter(email);

                MailMessage mailMessage = new Builder.ZooMailBuilder()
                    .IsBodyHtmlFormat(true)
                    .SetSubject(welcomeLetter.GetSubject())
                    .SetBody(welcomeLetter.GetHtml())
                    .Build();


                mailMessage.To.Add(email);

                mailClient.Send(mailMessage);
            }
            catch (SmtpException e)
            {
                // To nothing
            }
        }

        public void Send(Event zooEvent, string email)
        {
            try
            {
                using var mailClient = Secrets.Secret.GetMailClient();

                var newEventLetter = new NewEventNewsletter(zooEvent, email);

                MailMessage mailMessage = new Builder.ZooMailBuilder()
                    .IsBodyHtmlFormat(true)
                    .SetSubject(newEventLetter.GetSubject())
                    .SetBody(newEventLetter.GetHtml())
                    .Build();

                mailMessage.To.Add(email);


                mailClient.Send(mailMessage);
            }
            catch (SmtpException e)
            {
                // To nothing
            }
        }
    }
}
