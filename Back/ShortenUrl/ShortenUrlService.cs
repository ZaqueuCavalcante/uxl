namespace Uxl.Back.ShortenUrl;

public class ShortenUrlService(UxlDbContext ctx)
{
    public async Task<UrlOut> Shorten(ShortenUrlIn data)
    {
        var url = new ShortUrl(data.Target);

        ctx.Add(url);

        var ok = false;
        while(!ok)
        {
            try
            {
                await ctx.SaveChangesAsync();
                ok = true;
            }
            catch (Exception)
            {
                url.GenerateHash();
            }
        }

        return url.ToOut();
    }
}
