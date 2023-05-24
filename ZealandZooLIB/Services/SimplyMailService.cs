using System.Net.Mail;
using ZealandZooLIB.Models;
using ZealandZooLIB.NewsletterHtml;

namespace ZealandZooLIB.Services
{
    public class SimplyMailService
    {
        public void Send(MailMessage mailMessage)
        {
            using var mailClient = Secrets.Secret.GetMailClient();

            mailMessage.To.Add("pete74s9@edu.zealand.dk");

            mailClient.Send(mailMessage);
        }

        public void SendSubscribedLetter(string email)
        {
            using var mailClient = Secrets.Secret.GetMailClient();

            var welcomeLetter = new SubscribedNewsletter(email);

            MailMessage mailMessage = new Builder.ZooMailBuilder()
                .IsBodyHtmlFormat(true)
                .SetSubject(welcomeLetter.GetSubject())
                .SetBody(welcomeLetter.GetHtml())
                .Build();

            mailMessage.To.Add("pete74s9@edu.zealand.dk");

            mailMessage.To.Add(email);

            mailClient.Send(mailMessage);
        }

        public void Send(NewsletterBase newsletterBase, List<Student> recipients)
        {
            using var mailClient = Secrets.Secret.GetMailClient();

            MailMessage mailMessage = new Builder.ZooMailBuilder()
                .IsBodyHtmlFormat(true)
                .SetSubject(newsletterBase.GetSubject())
                .SetBody(newsletterBase.GetHtml())
                .Build();

            mailMessage.To.Add("pete74s9@edu.zealand.dk");

            recipients.ForEach(recipient =>
            {
                if (recipient.Email != null) mailMessage.To.Add(recipient.Email);
            });


            mailClient.Send(mailMessage);
        }
    }
}
