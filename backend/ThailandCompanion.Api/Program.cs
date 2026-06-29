using ThailandCompanion.Api.Services;
using ThailandCompanion.Api.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IProvinceService, ProvinceService>();
builder.Services.AddControllers();

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

app.MapControllers();
app.Run();
