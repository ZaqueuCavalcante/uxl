namespace Uxl.Back.Configs;

public static class HttpConfigs
{
    public static void AddHttpConfigs(this IServiceCollection services)
    {
        services.AddRouting(options => options.LowercaseUrls = true);
    }

    public static void UseControllers(this IApplicationBuilder app)
    {
        app.UseEndpoints(options =>
        {
            options.MapControllers();
        });
    }
}
