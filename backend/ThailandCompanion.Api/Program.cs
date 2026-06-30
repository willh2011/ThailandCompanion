using ThailandCompanion.Api.Services;
using ThailandCompanion.Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using ThailandCompanion.Api.Data;
using ThailandCompanion.Api.Data.Seed;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProvinceService, ProvinceService>();
builder.Services.AddControllers();
builder.Services.AddScoped<IDistrictService, DistrictService>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Defaultconnection")));
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/api/health", () =>
{
    return Results.Ok(new
    {
        application = "Thailand Companion",
        version = "0.0.1",
        status = "Healthy",
        environment = app.Environment.EnvironmentName,
        utcTime = DateTime.UtcNow
    });
})
.WithName("HealthCheck");

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await DatabaseSeeder.SeedAsync(dbContext);
}
app.MapControllers();
app.Run();
