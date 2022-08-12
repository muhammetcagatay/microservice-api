using Book.API.Models.Base;

namespace Book.API.Data.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IQueryable<T> GetRepository<T>() where T : IEntity;
        Task AddAsync<T>(T entity) where T : IEntity;
        void Update<T>(T entity)where T : IEntity;
        void Remove<T>(T entity)where T : IEntity;
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
