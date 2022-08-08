using Movie.API.Models.Entities;

namespace Movie.API.Data.Repositories.Categories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task AddFilmAsync(string id, string film);
    }
}
