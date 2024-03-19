namespace Uxl.Back.ShortenUrl;

public class ShortenUrlService(UxlDbContext ctx)
{
    public async Task<UrlOut> Shorten(ShortenUrlIn data)
    {
        var url = new ShortUrl(data.Target);

        ctx.Add(url);
        await ctx.SaveChangesAsync();

        return url.ToOut();
    }
}
