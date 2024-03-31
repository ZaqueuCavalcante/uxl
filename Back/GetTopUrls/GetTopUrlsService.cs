namespace Uxl.Back.GetTopUrls;

public class GetTopUrlsService(UxlDbContext ctx)
{
    public async Task<List<TopUrlOut>> GetTop()
    {
        FormattableString sql = $@"
            SELECT hash, count(1) AS clicks
            FROM uxl.url_clicks
            GROUP BY hash
            ORDER BY count(1) DESC
            LIMIT 3
        ";

        var urls = await ctx.Database.SqlQuery<TopUrlOut>(sql).ToListAsync();

        return urls.ToList();
    }
}
