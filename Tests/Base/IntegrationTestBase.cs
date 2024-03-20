using Uxl.Back.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Uxl.Tests.Base;

public class IntegrationTestBase
{
    protected BackWebApplicationFactory _factory = null!;

    [OneTimeSetUp]
    public async Task OneTimeSetUp()
    {
        _factory = new BackWebApplicationFactory();
        using var scope = _factory.Services.CreateScope();
        var ctx = scope.ServiceProvider.GetRequiredService<UxlDbContext>();

        await ctx.ResetDbAsync();
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDown()
    {
        await _factory.DisposeAsync();
    }
}
