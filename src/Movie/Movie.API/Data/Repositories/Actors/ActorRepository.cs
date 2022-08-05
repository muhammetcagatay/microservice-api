using Movie.API.Models.Entities;

namespace Movie.API.Data.Repositories.Actors
{
    public class CategoryRepository : GenericRepository<Actor>, ICategoriesRepository
    {
        public CategoryRepository(IMongoDataContext context) : base(context)
        {
        }
    }
}
