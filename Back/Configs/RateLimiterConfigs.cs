using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;

namespace Uxl.Back.Configs;

public static class RateLimiterConfigs
{
    public static void AddRateLimiterConfigs(this IServiceCollection services)
    {
        services.AddRateLimiter(options =>
        {
            options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

            if (Env.IsTesting() || Env.IsDevelopment())
            {
                options.AddFixedWindowLimiter("Small", o => { o.PermitLimit = 1000; o.Window = TimeSpan.FromHours(1); });
                return;
            }

            options.AddPolicy("Small", httpContext =>
                RateLimitPartition.GetFixedWindowLimiter(
                    partitionKey: httpContext.Connection.RemoteIpAddress?.ToString(),
                    factory: _ => new FixedWindowRateLimiterOptions
                    {
                        PermitLimit = 10,
                        Window = TimeSpan.FromHours(1)
                    }));
        });
    }
}
