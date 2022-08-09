using AutoMapper;
using Movie.API.Data.Repositories.Categories;
using Movie.API.Data.Repositories.Films;
using Movie.API.Models.Base;
using Movie.API.Models.Entities;
using Movie.API.Models.Request.Categories;
using Movie.API.Models.Response.Categories;
using Movie.API.Models.Response.Films;

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
        public async Task<Response<ResponseGetCategory>> GetByIdAsync(string id)
        {
            var category = await _categoryRepository.GetAsync(id);

            if (category == null)
            {
                return Response<ResponseGetCategory>.Fail("Not Found Category", 404);
            }

            var responseGetCategory = _mapper.Map<ResponseGetCategory>(category);

            return Response<ResponseGetCategory>.Success(200, responseGetCategory);
        }
        public async Task<Response<IEnumerable<ResponseGetCategory>>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();

            if (categories == null)
            {
                return Response<IEnumerable<ResponseGetCategory>>.Fail("Not Found Category", 404);
            }

            var responseGetCategories = _mapper.Map<IEnumerable<ResponseGetCategory>>(categories);

            return Response<IEnumerable<ResponseGetCategory>>.Success(200, responseGetCategories);
        }
        public async Task<Response<ResponseGetCategoryWithFilms>> GetCategoryWithFilms(string id)
        {
            var category = await _categoryRepository.GetAsync(id);

            if (category == null)
            {
                return Response<ResponseGetCategoryWithFilms>.Fail("Not Found Category", 404);
            }

            var responseGetCategoryWithFilms = _mapper.Map<ResponseGetCategoryWithFilms>(category);

            var films = new List<ResponseFilm>();

            if (category.FilmsId!=null)
            {
                foreach (var item in category.FilmsId)
                {
                    var film = await _filmRepository.GetAsync(item);

                    var responseFilm = _mapper.Map<ResponseFilm>(film);

                    if(responseFilm!=null) films.Add(responseFilm);
                }
            }

            responseGetCategoryWithFilms.Films = films;

            return Response<ResponseGetCategoryWithFilms>.Success(200, responseGetCategoryWithFilms);
        }
        public async Task<Response<ResponseCreateCategory>> CreateAsync(RequestCategory requestCategory)
        {
            var category = _mapper.Map<Category>(requestCategory);

            await _categoryRepository.CreateAsync(category);

            var responseCreateCategory = _mapper.Map<ResponseCreateCategory>(category);

            return Response<ResponseCreateCategory>.Success(200, responseCreateCategory);
        }
        public async Task<Response<ResponseCategory>> UpdateAsync(string id, RequestCategory requestCategory)
        {
            var category = _mapper.Map<Category>(requestCategory);

            if (category == null)
            {
                return Response<ResponseCategory>.Fail("Not Found Category", 404);
            }

            category.Id = id;

            await _categoryRepository.UpdateAsync(id, category);

            var responseCategory = _mapper.Map<ResponseCategory>(category);

            return Response<ResponseCategory>.Success(200,responseCategory);
        }
        public async Task<Response<ResponseCategory>> RemoveAsync(string id)
        {
            var responseCategory = _mapper.Map<ResponseCategory>(await _categoryRepository.GetAsync(id));

            if (responseCategory == null)
            {
                return Response<ResponseCategory>.Fail("Not Found Category", 404);
            }

            await _categoryRepository.DeleteAsync(id);

            return Response<ResponseCategory>.Success(200, responseCategory);
        }
    }
}
