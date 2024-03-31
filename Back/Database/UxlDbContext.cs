namespace Uxl.Back.Database;

public class UxlDbContext(DatabaseSettings settings) : DbContext
{
    public DbSet<ShortUrl> Urls { get; set; }
    public DbSet<UrlClick> Clicks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(settings.ConnectionString);
        optionsBuilder.UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    public void ResetDb()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public async Task ResetDbAsync()
    {
        await Database.EnsureDeletedAsync();
        await Database.EnsureCreatedAsync();
    }
}
