using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealandZooLIB.NewsletterHtml
{
    public abstract class NewsletterBase
    {
        protected NewsletterBase(string email)
        {
            this.email = email;
        }

        public string email { get; set; } 
        public abstract string GetHtml();
        public abstract string GetSubject();
    }
}
