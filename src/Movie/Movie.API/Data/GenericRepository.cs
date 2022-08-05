using MongoDB.Driver;
using Movie.API.Models.Base;
using System.Linq.Expressions;

namespace Movie.API.Data
{
    public class GenericRepository<T> : IRepository<T> where T : IEntity
    {
        private readonly IMongoDataContext _context;
        private readonly IMongoCollection<T> _collection;
        public GenericRepository(IMongoDataContext context)
        {
            _context = context;
            _collection = _context.GetCollection<T>(typeof(T).Name);
        }
        public async Task<T> GetAsync(string id)
        {
            var entity = await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

            return entity;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await _collection.Find(x => true).ToListAsync();

            return entities;
        }
        public async Task CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }
        public async Task UpdateAsync(T entity)
        {
            await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
        }
        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        } 
    }
}
