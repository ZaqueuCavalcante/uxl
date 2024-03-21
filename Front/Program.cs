using Front.Components;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

var url = builder.Environment.IsDevelopment() ?
    "http://localhost:5001" : "https://uxl-api.zaqbit.com";

builder.Services.AddMudServices();

builder.Services
    .AddHttpClient("HttpClient", x => x.BaseAddress = new Uri(url));

builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient("HttpClient"));

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

app.UseStaticFiles();
app.UseAntiforgery( );

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
