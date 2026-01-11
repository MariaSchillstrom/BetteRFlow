using BetteRFlow.Shared.Data;
using BetteRFlow.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<BetteRFlowContext>(options =>
{
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
});


// CORS-konfiguration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", policy =>
    {
        policy
            .WithOrigins("https://localhost:7026")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Database setup - EFTER app.Build()
using (var scope = app.Services.CreateScope())
{
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<BetteRFlowContext>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

        logger.LogInformation("Starting database setup...");

        if (app.Environment.IsProduction())
        {
            db.Database.EnsureCreated();  // Skapa tabeller direkt från modellen
        }
        else
        {
            db.Database.Migrate();  // Lokalt använd migrations
        }

        logger.LogInformation("Database setup completed!");
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while setting up the database.");
    }
}

// Configure the HTTP request pipeline
app.UseSwagger();
app.UseSwaggerUI();

if (!app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.UseRouting();
app.UseCors("AllowBlazorClient");
app.UseAuthentication();
app.UseAuthorization();

// ✅ SIDBESÖKS-LOGGNING (RÄTT PLATS)
app.Use(async (context, next) =>
{
    using var scope = context.RequestServices.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<BetteRFlowContext>();

    if (!context.Request.Path.StartsWithSegments("/_blazor") &&
        !context.Request.Path.StartsWithSegments("/swagger"))
    {
        db.PageViews.Add(new PageView
        {
            Path = context.Request.Path
        });

        await db.SaveChangesAsync();
    }

    await next();
});

app.MapControllers();
app.MapGet("/", () => Results.Redirect("/swagger"))
   .ExcludeFromDescription();

app.Run();


