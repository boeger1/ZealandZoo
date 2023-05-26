using System.Net.Mail;
using ZealandZooLIB.Models;
using ZealandZooLIB.NewsletterHtml;

namespace ZealandZooLIB.Services
{
    public class SimplyMailService
    {
        public void SendSubscribedLetter(string email)
        {
            using var mailClient = Secrets.Secret.GetMailClient();

            var welcomeLetter = new SubscribedNewsletter(email);

            SendNewsletter(email, welcomeLetter, mailClient);
        }

        public void SendEventNewLetter(Event zooEvent, string email)
        {
            using var mailClient = Secrets.Secret.GetMailClient();

            var newEventLetter = new NewEventNewsletter(zooEvent, email);

            SendNewsletter(email, newEventLetter, mailClient);
        }

        private void SendNewsletter(string email, NewsletterBase newsLetter, SmtpClient mailClient)
        {
            MailMessage mailMessage = new Builder.ZooMailBuilder()
                .IsBodyHtmlFormat(true)
                .SetSubject(newsLetter.GetSubject())
                .SetBody(newsLetter.GetHtml())
                .Build();

            mailMessage.To.Add(email);

            mailClient.Send(mailMessage);
        }
    }
}
