using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(Path.GetDirectoryName(System.AppContext.BaseDirectory))
        .AddJsonFile("appsettings.Production.json");
builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();

app.UseOcelot().Wait();

app.Run();