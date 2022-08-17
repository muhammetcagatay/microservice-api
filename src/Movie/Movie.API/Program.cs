using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Movie.API.Data;
using Movie.API.Data.Repositories.Actors;
using Movie.API.Data.Repositories.Categories;
using Movie.API.Data.Repositories.Films;
using Movie.API.Logging;
using Movie.API.Middlewares;
using Movie.API.Models.Settings;
using Movie.API.Services.Actors;
using Movie.API.Services.Categories;
using Movie.API.Services.Films;
using Serilog;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IActorRepository, ActorRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped(typeof(IActorService), typeof(ActorService));
builder.Services.AddScoped(typeof(IFilmService), typeof(FilmService));
builder.Services.AddScoped(typeof(ICategoryService), typeof(CategoryService));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<IMongoDbSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);
builder.Services.AddSingleton<IMongoDataContext, MongoDataContext>();

builder.Services.AddSwaggerGen();

builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();