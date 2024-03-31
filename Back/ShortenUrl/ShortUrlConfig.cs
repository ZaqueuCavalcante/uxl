namespace Uxl.Back.ShortenUrl;

public class ShortUrlConfig : IEntityTypeConfiguration<ShortUrl>
{
    public void Configure(EntityTypeBuilder<ShortUrl> url)
    {
        url.ToTable("urls");

        url.HasKey(u => u.Id);

        url.HasIndex(u => u.Hash).IsUnique();
    }
}
