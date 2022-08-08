using MongoDB.Driver;
using Movie.API.Models.Entities;

namespace Movie.API.Data.Repositories.Categories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly IMongoDataContext _context;
        private readonly IMongoCollection<Category> _collection;
        public CategoryRepository(IMongoDataContext context) : base(context)
        {
            _context = context;
            _collection = _context.GetCollection<Category>(typeof(Category).Name);
        }

        public async Task AddFilmAsync(string id, string film)
        {
            var category = await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

            category.FilmsId.Add(film);

            await _collection.ReplaceOneAsync(x => x.Id == id, category);
        }
    }
}
