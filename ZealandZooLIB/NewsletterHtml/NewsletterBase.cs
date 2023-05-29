namespace ZealandZooLIB.NewsletterHtml;

/// <summary>
///     Peter
/// </summary>
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