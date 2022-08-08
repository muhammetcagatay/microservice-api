using AutoMapper;
using Movie.API.Data.Repositories.Categories;
using Movie.API.Data.Repositories.Films;
using Movie.API.Models.Base;
using Movie.API.Models.Request.Categories;
using Movie.API.Models.Response.Categories;

namespace Movie.API.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFilmRepository _filmRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IFilmRepository filmRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _filmRepository = filmRepository;
            _mapper = mapper;
        }
        public Task<Response<ResponseGetCategory>> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
        public Task<Response<IEnumerable<ResponseGetCategory>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<Response<ResponseGetCategoryWithFilms>> GetCategoryWithFilms(string id)
        {
            throw new NotImplementedException();
        }
        public Task<Response<ResponseCreateCategory>> CreateAsync(RequestCategory requestCategory)
        {
            throw new NotImplementedException();
        }
        public Task<Response<ResponseCategory>> UpdateAsync(string id, RequestCategory requestCategory)
        {
            throw new NotImplementedException();
        }
        public Task<Response<ResponseCategory>> RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
