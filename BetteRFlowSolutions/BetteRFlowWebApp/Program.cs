using BetteRFlowWebApp.Components;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

// Lägg till HttpClient HÄR (innan app.Build())
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddHttpClient("ApiClient", client =>
{
    var apiUrl = builder.Configuration["ApiUrl"];

    if (string.IsNullOrWhiteSpace(apiUrl))
        throw new Exception("ApiUrl is not configured");

    client.BaseAddress = new Uri(apiUrl);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(BetteRFlowWebApp.Components.Pages.Admin.AdminDashboard).Assembly);


app.Run();
