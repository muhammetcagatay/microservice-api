using Book.API.Data;
using Book.API.Data.UnitOfWorks;
using Book.API.Filters;
using Book.API.Middlewares;
using Book.API.Services.Authors;
using Book.API.Services.BookEntities;
using Book.API.Services.Categories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(IAuthorService), typeof(AuthorService));
builder.Services.AddScoped(typeof(IBookService), typeof(BookService));
builder.Services.AddScoped(typeof(ICategoryService), typeof(CategoryService));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<BookDataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL")));

builder.Services.AddScoped(typeof(NotFoundFilter<>));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<BookDataContext>();
    dataContext.Database.Migrate();
}


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseMiddleware<LoggingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
