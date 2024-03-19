namespace Uxl.Back.Database;

public class UxlDbContext(DatabaseSettings settings) : DbContext
{
    public DbSet<ShortUrl> Urls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(settings.ConnectionString);
        optionsBuilder.UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.HasDefaultSchema("uxl");

        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<Enum>().HaveConversion<string>();
    }

    public void ResetDb()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public void MigrateDb()
    {
        Database.Migrate();
    }
}
