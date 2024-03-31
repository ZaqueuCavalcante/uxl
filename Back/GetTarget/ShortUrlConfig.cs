namespace Uxl.Back.ShortenUrl;

public class UrlClickConfig : IEntityTypeConfiguration<UrlClick>
{
    public void Configure(EntityTypeBuilder<UrlClick> url)
    {
        url.ToTable("url_clicks");

        url.HasKey(u => u.Id);
    }
}
