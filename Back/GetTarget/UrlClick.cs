namespace Uxl.Back.ShortenUrl;

public class UrlClick
{
    public Guid Id { get; set; }
    public string Hash { get; set; }
    public DateTime CreatedAt { get; set; }

    public UrlClick(string hash)
    {
        Id = Guid.NewGuid();
        Hash = hash;
        CreatedAt = DateTime.Now;
    }
}
