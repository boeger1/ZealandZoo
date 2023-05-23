using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ZealandZooLIB.Models;

namespace ZealandZooLIB.Builder
{
    public class ZooMailBuilder
    {
        private const string FromAdrStr = "zoo.news@heltengaston.dk";
        private  readonly MailAddress _fromAdr = new MailAddress(FromAdrStr);
        private MailMessage _mail;

        public ZooMailBuilder()
        {
            _mail = new MailMessage();
        }

        public ZooMailBuilder SetSubject(string subject)
        {
            _mail.Subject = subject;
            return this;
        }

        public ZooMailBuilder SetBody(string body)
        {
            _mail.Body = body;
            return this;
        }

        public ZooMailBuilder IsBodyHtmlFormat(bool isHtml)
        {
            _mail.IsBodyHtml = isHtml;
            return this;
        }

        private ZooMailBuilder SetFrom(MailAddress from)
        {
            _mail.From = from;
            return this;
        }

        public MailMessage Build()
        {
            SetFrom(_fromAdr);
            return _mail;
        }
    }
}
