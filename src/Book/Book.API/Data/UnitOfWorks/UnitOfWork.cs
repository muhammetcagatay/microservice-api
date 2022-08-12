using Book.API.Models.Base;

namespace Book.API.Data.UnitOfWorks
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : IEntity
    {
        private readonly BookDataContext _context;

        public UnitOfWork(BookDataContext context)
        {
            _context = context;
        }
        public IQueryable<T> GetRepository()
        {
            return _context.Set<T>().AsQueryable();
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public void Remove(T entity)
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
