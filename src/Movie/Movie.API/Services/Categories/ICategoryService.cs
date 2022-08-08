using Movie.API.Models.Base;
using Movie.API.Models.Request.Categories;
using Movie.API.Models.Response.Categories;

namespace Movie.API.Services.Categories
{
    public interface ICategoryService
    {
        Task<Response<ResponseGetCategory>> GetByIdAsync(string id);
        Task<Response<IEnumerable<ResponseGetCategory>>> GetAllAsync();
        Task<Response<ResponseGetCategoryWithFilms>> GetCategoryWithFilms(string id);
        Task<Response<ResponseCreateCategory>> CreateAsync(RequestCategory requestCategory);
        Task<Response<ResponseCategory>> UpdateAsync(string id, RequestCategory requestCategory);
        Task<Response<ResponseCategory>> RemoveAsync(string id);
    }
}
