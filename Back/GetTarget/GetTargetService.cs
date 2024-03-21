using Uxl.Shared.GetTargetUrl;

namespace Uxl.Back.GetTarget;

public class GetTargetService(UxlDbContext ctx)
{
    public async Task<TargetUrlOut> Get(string hash)
    {
        var url = await ctx.Urls.FirstOrDefaultAsync(x => x.Hash == hash);

        if (url == null)
            return new() { Target = "" };

        url.Clicks++;

        await ctx.SaveChangesAsync();

        return new() { Target = url.Target };
    }
}
