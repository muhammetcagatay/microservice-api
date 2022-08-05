using Movie.API.Models.Base;
using System.Linq.Expressions;

namespace Movie.API.Data
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task CreateAsync(T entity);
        Task UpdateAsync(string id,T entity);
        Task DeleteAsync(string id);
    }
}
