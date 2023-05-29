using System.Net.Mail;

namespace ZealandZooLIB.Builder;

/// <summary>
///     Peter
/// </summary>
public class ZooMailBuilder
{
    public const string FromAdrStr = "zoo.news@heltengaston.dk";
    private readonly MailAddress _fromAdr = new(FromAdrStr);
    private readonly MailMessage _mail;


    /// <summary>
    ///     Peter
    /// </summary>
    public ZooMailBuilder()
    {
        _mail = new MailMessage();
    }

    /// <summary>
    ///     Peter
    /// </summary>
    /// <param name="subject"></param>
    /// <returns></returns>
    public ZooMailBuilder SetSubject(string subject)
    {
        _mail.Subject = subject;
        return this;
    }

    /// <summary>
    ///     Peter
    /// </summary>
    /// <param name="body"></param>
    /// <returns></returns>
    public ZooMailBuilder SetBody(string body)
    {
        _mail.Body = body;
        return this;
    }

    /// <summary>
    ///     Peter
    /// </summary>
    /// <param name="isHtml"></param>
    /// <returns></returns>
    public ZooMailBuilder IsBodyHtmlFormat(bool isHtml)
    {
        _mail.IsBodyHtml = isHtml;
        return this;
    }

    /// <summary>
    ///     Peter
    /// </summary>
    /// <param name="from"></param>
    /// <returns></returns>
    private ZooMailBuilder SetFrom(MailAddress from)
    {
        _mail.From = from;
        return this;
    }

    /// <summary>
    ///     Peter
    /// </summary>
    /// <returns></returns>
    public MailMessage Build()
    {
        SetFrom(_fromAdr);
        return _mail;
    }
}