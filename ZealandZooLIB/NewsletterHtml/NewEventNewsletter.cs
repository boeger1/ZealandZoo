using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZealandZooLIB.Models;

namespace ZealandZooLIB.NewsletterHtml
{
    public class NewEventNewsletter : NewsletterBase
    {
        private Event _zooEvent;
        public NewEventNewsletter(Event zooEvent, string email) : base(email) 
        {
            _zooEvent = zooEvent;
        }
        public override string GetHtml()
        {
            return
                $"<!DOCTYPE html>\r\n<html lang=\"en\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Document</title>\r\n    <style>\r\n        @import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@200&display=swap');\r\n        body {{\r\n            font-family: 'Montserrat', sans-serif;\r\n          background-color: #f1f1f1;\r\n          padding: 20px;\r\n        }}\r\n      </style></head>\r\n<body>\r\n    <div class=\"EventInfo\">\r\n\r\n        <br /> \r\n                    \r\n        <h3 name=\"Name\">{_zooEvent.Name}</h3>\r\n\r\n        <br />\r\n\r\n        <p name=\"Description\">{_zooEvent.Description}</p>\r\n        <p name=\"Price\"> pris: {_zooEvent.Price} kr </p>\r\n     \r\n        <p name=\"DateFrom\"> Begynder: {_zooEvent.DateFrom.ToString("dddd")} Den {_zooEvent.DateFrom.ToString("dd MMMM")} kl: {_zooEvent.DateFrom.ToString("HH:mm")} </p>\r\n        <p name=\"DateTo\">   Slutter:  {_zooEvent.DateTo.ToString("dddd")}   Den {_zooEvent.DateTo.ToString("dd MMMM")}   kl: {_zooEvent.DateTo.ToString("HH:mm")} </p>\r\n        \r\n\r\n        <br />        \r\n       \r\n               <p>Bedste Hilsner</p>\r\n  \r\n        <img width=\"190\" height=\"50\" viewbox=\"150 50\" src=\"https://svgshare.com/i/tMK.svg\" a=\"\" href=\"https://svgshare.com/s/tMK\" title=\"logo\">       <br />\r\n    </div>\r\n</body>\r\n</html>";
        }

        public override string GetSubject()
        {
            return $"Zoo Event: {_zooEvent.Name}";
        }
    }
}
