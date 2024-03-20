namespace Uxl.Back.Redirect;

public class RedirectService(UxlDbContext ctx)
{
    public async Task<string> GetTarget(string hash)
    {
        var url = await ctx.Urls.FirstOrDefaultAsync(x => x.Hash == hash);

        if (url == null)
            return "";

        url.Clicks++;

        await ctx.SaveChangesAsync();

        return url.Target;
    }
}
