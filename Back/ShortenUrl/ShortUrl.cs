namespace Uxl.Back.ShortenUrl;

public class ShortUrl
{
    public Guid Id { get; set; }
    public string Hash { get; set; }
    public string Target { get; set; }
    public ulong Clicks { get; set; }
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
        var hash = $"{Guid.NewGuid().ToString()[..7]}";

        var rand = new Random();
        int index = rand.Next(hash.Length);
        var first = hash[index];

        char[] chars = hash.ToCharArray();
        chars[index] = first;
        Hash = new string(chars);
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
            Clicks = Clicks,
        };
    }
}
