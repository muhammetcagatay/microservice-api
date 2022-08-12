using Book.API.Models.Base;

namespace Book.API.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookDataContext _context;

        public UnitOfWork(BookDataContext context)
        {
            _context = context;
        }
        public IQueryable<T> GetRepository<T>() where T : IEntity
        {
            return _context.Set<T>().AsQueryable();
        }
        public async Task AddAsync<T>(T entity) where T : IEntity
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public void Update<T>(T entity) where T : IEntity
        {
            _context.Set<T>().Update(entity);
        }
        public void Remove<T>(T entity) where T : IEntity
        {
            _context.Set<T>().Remove(entity);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
