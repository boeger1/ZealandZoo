using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZealandZooLIB.Models;

namespace ZealandZooLIB.NewsletterHtml
{
    public class ContactEmail : NewsletterBase
    {
        private readonly ContactFormular _formular;

        public ContactEmail(ContactFormular formular) : base(formular.SenderEmail)
        {
            _formular = formular;
        }

        public override string GetHtml()
        {
            return $@"<!DOCTYPE html>
                        <html lang=""en"">
                        <head>
                          <meta charset=""UTF-8"">
                          <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
                          <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                          <title>Document</title>
                        </head>
                        <body>
                          <h3>Fra: {_formular.SenderName}</h3>
                          <p>{_formular.MailBody}</p>
                          <p>{_formular.SenderEmail}</p>
                        </body>
                        </html>
                        ";
        }

        public override string GetSubject()
        {
            return $"Forespørgsel fra: " + _formular.SenderName;
        }
    }
}
