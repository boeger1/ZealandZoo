using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealandZooLIB.NewsletterHtml
{
    public class ContactEmail : NewsletterBase
    {
        private readonly string _messeage;

        public ContactEmail(string messeage, string senderEmail) : base(senderEmail)
        {
            _messeage = messeage;
        }

        public override string GetHtml()
        {
            throw new NotImplementedException();
        }

        public override string GetSubject()
        {
            throw new NotImplementedException();
        }
    }
}
