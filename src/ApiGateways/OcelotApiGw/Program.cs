using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", true, true);

builder.Logging.AddConfiguration(configuration.GetSection("Logging"));
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// Services
builder.Services.AddOcelot();

var app = builder.Build();

// Middleware Pipeline
app.MapGet("/", () => "Hello World!");

await app.UseOcelot();

app.Run();
