namespace Uxl.Back.Configs;

public static class ServicesConfigs
{
    public static void AddServicesConfigs(this IServiceCollection services)
    {
        services.AddScoped<GetTargetService>();
        services.AddScoped<ShortenUrlService>();
        services.AddScoped<GetTopUrlsService>();
    }
}
