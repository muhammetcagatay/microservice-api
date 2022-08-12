using Book.API.Data;
using Book.API.Models.Request.Books;
using Book.API.Models.Response.Books;

namespace Book.API.Services.BookEntities
{
    public interface IBookService
    {
        Task<Response<BookResponse>> GetByIdAsync(int id);
        Task<Response<IEnumerable<BookResponse>>> GetAllAsync();
        Task<Response<int>> CreateAsync(BookRequest request);
        Task<Response<NoContent>> UpdateAsync(int id, BookRequest request);
        Task<Response<NoContent>> DeleteAsync(int id);
    }
}
