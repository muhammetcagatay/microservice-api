using Book.API.Data;
using Book.API.Models.Entities;
using Book.API.Models.Request.Authors;
using Book.API.Models.Response.Authors;

namespace Book.API.Services.Authors
{
    public interface IAuthorService
    {
        Task<Response<AuthorResponse>> GetByIdAsync(int id);
        Task<Response<IEnumerable<Author>>> GetAllAsync();
        Task<Response<AuthorWithBooksResponse>> GetAuthorWithBooksAsync(int id);
        Task<Response<int>> CreateAsync(AuthorRequest request);
        Task<Response<NoContent>> UpdateAsync(int id, AuthorRequest request);
        Task<Response<NoContent>> DeleteAsync(int id);
    }
}
