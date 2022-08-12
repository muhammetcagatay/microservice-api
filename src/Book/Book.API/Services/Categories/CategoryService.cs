using AutoMapper;
using Book.API.Data;
using Book.API.Data.UnitOfWorks;
using Book.API.Models.Entities;
using Book.API.Models.Request.Categories;
using Book.API.Models.Response.Categories;
using Microsoft.EntityFrameworkCore;

namespace Book.API.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork<Category> _unitOfWork;
        private readonly IMapper _mapper;
        public CategoryService(IUnitOfWork<Category> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<CategoryResponse>> GetByIdAsync(int id)
        {
            var categoryRepository = _unitOfWork.GetRepository();

            var category = await categoryRepository.Where(x => x.Id == id).Where(x => !x.IsDelete).SingleAsync();

            var categoryResponse = _mapper.Map<CategoryResponse>(category);

            return Response<CategoryResponse>.Success(200, categoryResponse);
        }
        public async Task<Response<IEnumerable<CategoryResponse>>> GetAllAsync()
        {
            var categoryRepository = _unitOfWork.GetRepository();

            var categories = await categoryRepository.Where(x => !x.IsDelete).ToListAsync();

            var categoriesResponse = _mapper.Map<IEnumerable<CategoryResponse>>(categories);

            return Response<IEnumerable<CategoryResponse>>.Success(200, categoriesResponse);
        }
        public async Task<Response<CategoryWithBooksResponse>> GetCategoryWithBooksAsync(int id)
        {
            var categoryRepository = _unitOfWork.GetRepository();

            var category = await categoryRepository.Include(x => x.Books).Where(x => x.Id == id).Where(x => !x.IsDelete).SingleAsync();

            var categoryResponse = _mapper.Map<CategoryWithBooksResponse>(category);

            return Response<CategoryWithBooksResponse>.Success(200, categoryResponse);
        } 
        public async Task<Response<int>> CreateAsync(CategoryRequest request)
        {
            var category = _mapper.Map<Category>(request);

            await _unitOfWork.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();

            return Response<int>.Success(200, category.Id);
        }
        public async Task<Response<NoContent>> UpdateAsync(int id, CategoryRequest request)
        {
            var categoryRepository = _unitOfWork.GetRepository();

            var category = await categoryRepository.Where(x => x.Id == id).Where(x => !x.IsDelete).SingleAsync();

            category.Name = request.Name;

            _unitOfWork.Update(category);
            await _unitOfWork.SaveChangesAsync();

            return Response<NoContent>.Success(200);
        }
        public async Task<Response<NoContent>> DeleteAsync(int id)
        {
            var categoryRepository = _unitOfWork.GetRepository();

            var category = await categoryRepository.Where(x => x.Id == id).Where(x => !x.IsDelete).SingleAsync();

            category.IsDelete = true;

            _unitOfWork.Update(category);
            await _unitOfWork.SaveChangesAsync();

            return Response<NoContent>.Success(200);
        }
    }
}
