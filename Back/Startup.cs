namespace Uxl.Back;

public class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddSettingsConfigs();
        services.AddServicesConfigs();

        services.AddControllers();
        services.AddHttpConfigs();

        services.AddEfCoreConfigs();
        services.AddCorsConfigs();
    }

    public static void Configure(IApplicationBuilder app, UxlDbContext ctx)
    {
        ctx.ResetDb();

        app.UseCors();

        app.UseRouting();

        app.UseControllers();
    }
}
