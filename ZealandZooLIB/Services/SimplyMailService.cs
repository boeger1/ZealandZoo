using System.Net.Mail;
using ZealandZooLIB.Builder;
using ZealandZooLIB.Models;
using ZealandZooLIB.NewsletterHtml;
using ZealandZooLIB.Secrets;

namespace ZealandZooLIB.Services
{
    /// <summary>
    /// Peter
    /// </summary>
    public class SimplyMailService
    {
        /// <summary>
        /// Peter
        /// </summary>
        /// <param name="email"></param>
        public void SendSubscribedLetter(string email)
        {
            var welcomeLetter = new SubscribedNewsletter(email);

            CreateNewsletter(email, welcomeLetter);
        }

        /// <summary>
        /// Peter
        /// </summary>
        /// <param name="zooEvent"></param>
        /// <param name="email"></param>
        public void SendEventNewLetter(Event zooEvent, string email)
        {
            var newEventLetter = new NewEventNewsletter(zooEvent, email);

            CreateNewsletter(email, newEventLetter);
        }

        /// <summary>
        /// Peter
        /// </summary>
        /// <param name="Formular"></param>
        /// <param name="recipientsList"></param>
        public void SendContactLetter(ContactFormular Formular, List<Student> recipientsList)
        {
            var contactEmail = new ContactEmail(Formular);

            recipientsList.ForEach(student => CreateNewsletter(student.Email!, contactEmail));
        }

        /// <summary>
        /// Peter
        /// </summary>
        /// <param name="email"></param>
        /// <param name="newsLetter"></param>
        private void CreateNewsletter(string email, NewsletterBase newsLetter)
        {
            MailMessage mailMessage = new ZooMailBuilder()
                .IsBodyHtmlFormat(true)
                .SetSubject(newsLetter.GetSubject())
                .SetBody(newsLetter.GetHtml())
                .Build();

            SendEmail(email, mailMessage);
        }


        /// <summary>
        /// Peter
        /// </summary>
        /// <param name="email"></param>
        /// <param name="mailMessage"></param>
        private void SendEmail(string email, MailMessage mailMessage)
        {
            using var mailClient = Secret.GetMailClient();

            mailMessage.To.Add(email);

            try
            {
                mailClient.Send(mailMessage);
            }
            catch (SmtpException e)
            {
                // TO NOTHING
            }
        }
    }
}