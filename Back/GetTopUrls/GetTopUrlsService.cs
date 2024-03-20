namespace Uxl.Back.GetTopUrls;

public class GetTopUrlsService(UxlDbContext ctx)
{
    public async Task<List<TopUrlOut>> GetTop()
    {
        var urls = await ctx.Urls
            .OrderByDescending(x => x.Clicks)
            .Take(3)
            .ToListAsync();

        return urls.ConvertAll(x => x.ToTopOut());
    }
}
