namespace Uxl.Back;

public class Startup
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddSettingsConfigs();
        services.AddServicesConfigs();

        services.AddRateLimiterConfigs();

        services.AddControllers();
        services.AddHttpConfigs();

        services.AddEfCoreConfigs();
        services.AddCorsConfigs();
    }

    public static void Configure(IApplicationBuilder app)
    {
        app.UseCors();

        app.UseRouting();

        app.UseRateLimiter();

        app.UseControllers();
    }
}
