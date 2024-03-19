namespace Uxl.Back.ShortenUrl;

public class ShortUrl
{
    public Guid Id { get; set; }
    public string Hash { get; set; }
    public string Target { get; set; }
    public DateTime CreatedAt { get; set; }

    public ShortUrl(
        string target
    ) {
        Id = Guid.NewGuid();
        Hash = $"{Guid.NewGuid().ToString()[..6]}";
        Target = target;
        CreatedAt = DateTime.Now;
    }

    public UrlOut ToOut()
    {
        return new UrlOut
        {
            Hash = Hash,
        };
    }
}
