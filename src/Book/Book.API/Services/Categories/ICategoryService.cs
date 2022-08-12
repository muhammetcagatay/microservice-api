using Book.API.Data;
using Book.API.Models.Request.Categories;
using Book.API.Models.Response.Categories;

namespace Book.API.Services.Categories
{
    public interface ICategoryService
    {
        Task<Response<CategoryResponse>> GetByIdAsync(int id);
        Task<Response<IEnumerable<CategoryResponse>>> GetAllAsync();
        Task<Response<CategoryWithBooksResponse>> GetCategoryWithBooksAsync(int id);
        Task<Response<int>> CreateAsync(CategoryRequest request);
        Task<Response<NoContent>> UpdateAsync(int id, CategoryRequest request);
        Task<Response<NoContent>> DeleteAsync(int id);
    }
}
