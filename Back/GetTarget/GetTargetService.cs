using Uxl.Shared.GetTargetUrl;

namespace Uxl.Back.GetTarget;

public class GetTargetService(UxlDbContext ctx)
{
    public async Task<TargetUrlOut> Get(string hash)
    {
        var url = await ctx.Urls.AsNoTracking().FirstOrDefaultAsync(x => x.Hash == hash);

        if (url == null)
            return new() { Target = "" };

        var click = new UrlClick(url.Hash);
        ctx.Add(click);
        await ctx.SaveChangesAsync();

        return new() { Target = url.Target };
    }
}
