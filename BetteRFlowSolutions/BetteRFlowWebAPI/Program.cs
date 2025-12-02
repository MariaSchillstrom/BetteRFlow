using BetteRFlow.Shared.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add the DbContext BetteRFlowContext
// Use Sqlite for Development, and SqlServer / Azure for Production
builder.Services.AddDbContext<BetteRFlowContext>(options =>
    options.UseSqlite("Data Source="));

// CORS-konfiguration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", policy =>
    {
        policy
            .WithOrigins("https://localhost:7026") // Blazor-appens URL
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowBlazorClient"); // Viktigt: mellan UseRouting och UseAuthorization
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

