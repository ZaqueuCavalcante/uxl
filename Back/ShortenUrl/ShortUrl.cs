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
        Target = target;
        GenerateHash();
        CreatedAt = DateTime.Now;
    }

    public void GenerateHash()
    {
        var bytes = Guid.NewGuid().ToByteArray();
        Hash = bytes.ToBase62()[..7];
    }

    public UrlOut ToOut()
    {
        return new UrlOut
        {
            Hash = Hash,
        };
    }

    public TopUrlOut ToTopOut()
    {
        return new TopUrlOut
        {
            Hash = Hash,
        };
    }
}
