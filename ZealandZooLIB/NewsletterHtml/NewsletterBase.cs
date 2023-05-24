using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZealandZooLIB.NewsletterHtml
{
    public abstract class NewsletterBase
    {
        public int Id { get; set; } = 0;
        public abstract string GetHtml();
        public abstract string GetSubject();
    }
}
