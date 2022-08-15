using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("configuration.devolopment.json").AddEnvironmentVariables();

builder.Services.AddOcelot();

var app = builder.Build();

await app.UseOcelot();

app.Run();
