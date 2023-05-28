using System.Net.Mail;
using ZealandZooLIB.Builder;
using ZealandZooLIB.Models;
using ZealandZooLIB.NewsletterHtml;

namespace ZealandZooLIB.Services
{
    public class SimplyMailService
    {
        public void SendSubscribedLetter(string email)
        {
            var welcomeLetter = new SubscribedNewsletter(email);

            CreateNewsletter(email, welcomeLetter);
        }

        public void SendEventNewLetter(Event zooEvent, string email)
        {
            var newEventLetter = new NewEventNewsletter(zooEvent, email);

            CreateNewsletter(email, newEventLetter);
        }

        public void SendContactLetter(ContactFormular Formular, List<Student> recipientsList)
        {
            var contactEmail = new ContactEmail(Formular);

            recipientsList.ForEach(student => CreateNewsletter(student.Email!, contactEmail));
        }


        private void CreateNewsletter(string email, NewsletterBase newsLetter)
        {
            MailMessage mailMessage = new ZooMailBuilder()
                .IsBodyHtmlFormat(true)
                .SetSubject(newsLetter.GetSubject())
                .SetBody(newsLetter.GetHtml())
                .Build();

            SendEmail(email, mailMessage);
        }

        private void SendEmail(string email, MailMessage mailMessage)
        {
            using var mailClient = Secrets.Secret.GetMailClient();

            mailMessage.To.Add(email);

            mailClient.Send(mailMessage);
        }
    }
}