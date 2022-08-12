using Book.API.Models.Base;

namespace Book.API.Data.UnitOfWorks
{
    public interface IUnitOfWork<T> where T : IEntity
    {
        IQueryable<T> GetRepository();
        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        void SaveChanges();
        Task SaveChangesAsync();

    }
}
