using System.Net.Mail;

namespace ZealandZooLIB.Services
{
    public class SimplyMailService
    {
        private const string DefaultSubject = "News From Zealand Zoo";
        private const string DefaultBody = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n  <meta charset=\"UTF-8\">\r\n  <title>Newsletter</title>\r\n  <style>\r\n    /* Global styles */\r\n    body {\r\n      font-family: Arial, sans-serif;\r\n      background-color: #f4f4f4;\r\n      margin: 0;\r\n      padding: 0;\r\n    }\r\n    \r\n    .container {\r\n      max-width: 600px;\r\n      margin: 0 auto;\r\n      background-color: #ffffff;\r\n      padding: 20px;\r\n      border-radius: 4px;\r\n      box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);\r\n    }\r\n    \r\n    h1 {\r\n      color: #333333;\r\n      margin-top: 0;\r\n    }\r\n    \r\n    p {\r\n      color: #666666;\r\n    }\r\n    \r\n    a {\r\n      color: #007bff;\r\n      text-decoration: none;\r\n    }\r\n    \r\n    /* Section styles */\r\n    .section {\r\n      margin-bottom: 20px;\r\n    }\r\n    \r\n    .section-title {\r\n      font-size: 20px;\r\n      font-weight: bold;\r\n      margin-bottom: 10px;\r\n    }\r\n    \r\n    .section-content {\r\n      font-size: 16px;\r\n    }\r\n    \r\n    /* Button styles */\r\n    .button {\r\n      display: inline-block;\r\n      background-color: #007bff;\r\n      color: #ffffff;\r\n      padding: 10px 20px;\r\n      border-radius: 4px;\r\n      text-decoration: none;\r\n    }\r\n  </style>\r\n</head>\r\n<body>\r\n  <div class=\"container\">\r\n    <h1>Newsletter</h1>\r\n    <p>Welcome to our newsletter! Stay updated with the latest news and updates.</p>\r\n    \r\n    <div class=\"section\">\r\n      <h2 class=\"section-title\">Section 1</h2>\r\n      <p class=\"section-content\">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut ut turpis id ex fermentum lobortis. Aliquam eleifend luctus mauris, at consectetur lacus facilisis at.</p>\r\n      <a href=\"#\" class=\"button\">Read More</a>\r\n    </div>\r\n    \r\n    <div class=\"section\">\r\n      <h2 class=\"section-title\">Section 2</h2>\r\n      <p class=\"section-content\">Nullam nec ipsum id enim facilisis vulputate. Fusce nec elit eget urna blandit sagittis. Nam finibus justo vel metus hendrerit, vitae luctus metus convallis.</p>\r\n      <a href=\"#\" class=\"button\">Read More</a>\r\n    </div>\r\n    \r\n    <div class=\"section\">\r\n      <h2 class=\"section-title\">Section 3</h2>\r\n      <p class=\"section-content\">Vestibulum tincidunt lorem sed massa fringilla, nec semper libero auctor. Proin a lectus in neque aliquet lobortis vitae sed mi.</p>\r\n      <a href=\"#\" class=\"button\">Read More</a>\r\n    </div>\r\n  </div>\r\n</body>\r\n</html>\r\n";

        //public void Send(MailMessage mailMessage)
        //{
        //    using var mailClient = Secrets.Secret.GetMailClient();

        //    mailMessage.To.Add("peno.ing@gmail.com");

        //    mailClient.Send(mailMessage);
        //}

        //public void Send()
        //{
        //    using var mailClient = Secrets.Secret.GetMailClient();

        //    MailMessage mailMessage = new Builder.ZooMailBuilder()
        //        .IsBodyHtmlFormat(true)
        //        .SetSubject(DefaultSubject)
        //        .SetBody(DefaultBody)
        //        .Build();

        //    mailMessage.To.Add("peno.ing@gmail.com");

        //    mailClient.Send(mailMessage);
        //}
    }
}
