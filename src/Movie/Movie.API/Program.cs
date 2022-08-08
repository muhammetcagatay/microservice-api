using Microsoft.Extensions.Options;
using Movie.API.Data;
using Movie.API.Data.Repositories.Actors;
using Movie.API.Data.Repositories.Categories;
using Movie.API.Data.Repositories.Films;
using Movie.API.Models.Settings;
using Movie.API.Services.Actors;
using Movie.API.Services.Films;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IActorRepository, ActorRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped(typeof(IActorService), typeof(ActorService));
builder.Services.AddScoped(typeof(IFilmService), typeof(FilmService));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<IMongoDbSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

builder.Services.AddSingleton<IMongoDataContext, MongoDataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
