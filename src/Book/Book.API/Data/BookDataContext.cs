using Book.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book.API.Data
{
    public class BookDataContext : DbContext
    {
        public BookDataContext(DbContextOptions<BookDataContext> options) : base(options)
        {

        }
        public DbSet<Author> authors { get; set; }
        public DbSet<BookEntity> books { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}
