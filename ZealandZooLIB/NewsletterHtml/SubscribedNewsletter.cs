namespace ZealandZooLIB.NewsletterHtml;

/// <summary>
///     Peter
/// </summary>
public class SubscribedNewsletter : NewsletterBase
{
    /// <summary>
    ///     Peter
    /// </summary>
    /// <param name="email"></param>
    public SubscribedNewsletter(string email) : base(email)
    {
    }

    /// <summary>
    ///     Peter
    /// </summary>
    /// <returns></returns>
    public override string GetHtml()
    {
        return
            $"<!DOCTYPE html>\r\n<html>\r\n<head>\r\n  <title>Newsletter Subscription Receipt</title>\r\n  <style>\r\n    @import url('https://fonts.googleapis.com/css2?family=Montserrat:wght@200&display=swap');\r\n    body {{\r\n        font-family: 'Montserrat', sans-serif;\r\n      background-color: #f1f1f1;\r\n      padding: 20px;\r\n    }}\r\n\r\n    .centered {{\r\n      text-align: center;\r\n    }}\r\n\r\n    hr {{\r\n        width: 20%;\r\n    }}\r\n\r\n    h2 {{\r\n      color: #333333;\r\n    }}\r\n\r\n    p {{\r\n      color: #555555;\r\n    }}\r\n\r\n    .event-link {{\r\n    color: rgba(194, 30, 86, 0.7);\r\n    opacity: 0.8;\r\n    font-size: 11px;\r\n    text-transform: uppercase;\r\n    letter-spacing: .2rem;\r\n    font-weight: 600;\r\n    text-shadow: 2px 2px 7px rgba(170,60,105,0.9);\r\n    text-decoration: none;\r\n}}\r\n\r\n    .event-link:hover {{\r\n        color: #009E0F;\r\n        opacity: 0.4;\r\n        cursor: pointer;\r\n    }}\r\n\r\n    .undellined {{\r\n        text-decoration: underline;\r\n    }}\r\n  </style>\r\n</head>\r\n<body>\r\n    <section class=\"centered\">\r\n  <h2>Tak for at tilmelde dig Zealand Zoo's nyhedsbrev</h2>\r\n  <hr/>\r\n\r\n  <p>Vi er glade for din interesse for at holde dig opdateret med nyheder og nye events så snart de bliver tilføjet!</p>\r\n  \r\n  <p>Tak for din tilmelding! <p>Du kan <a class=\"event-link\" href=\"http://zoo.heltengaston.dk/NewsLetter/UnsubscribeNewsLetter?email={email}\">Afmelde dig <span class=\"undellined\">her</span></a> Hvis du ikke længere ønske nyhedsbrevet</p>\r\n  \r\n  <p>Bedste Hilsner</p>\r\n  \r\n  <img width=\"190\" height=\"50\" viewbox=\"150 50\" src=\"https://svgshare.com/i/tMK.svg\" a=\"\" href=\"https://svgshare.com/s/tMK\" alt=\"Zoo\" title=\"logo\">\r\n</section>\r\n</body>\r\n</html>\r\n";
    }

    /// <summary>
    ///     Peter
    /// </summary>
    /// <returns></returns>
    public override string GetSubject()
    {
        return "Velkommen til Zoo's nyhedsbrev.";
    }
}