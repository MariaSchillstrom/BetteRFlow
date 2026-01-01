using BetteRFlow.Shared.Data;
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
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    if (builder.Environment.IsProduction())
    {
        var productionConnString = "Host=dpg-d5b68qogjchc73bolsmg-a;Port=5432;Database=betterflow;Username=betterflow_user;Password=dYsraEjzHuz8PiShmuieZWtbD48cd3PQ;SSL Mode=Require;Trust Server Certificate=true;";
        options.UseNpgsql(productionConnString);
    }
    else
    {
        options.UseSqlite(connectionString);
    }
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
app.MapControllers();
app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

app.Run();
