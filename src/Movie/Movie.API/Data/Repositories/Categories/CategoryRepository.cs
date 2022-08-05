using Movie.API.Models.Entities;

namespace Movie.API.Data.Repositories.Categories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(IMongoDataContext context) : base(context)
        {
        }
    }
}
