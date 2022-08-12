using AutoMapper;
using Book.API.Models.Entities;
using Book.API.Models.Request.Categories;
using Book.API.Models.Response.Categories;

namespace Book.API.Mapper
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryResponse>().ReverseMap();
            CreateMap<Category, CategoryRequest>().ReverseMap();
            CreateMap<Category, CategoryWithBooksResponse>().ReverseMap();
        }
    }
}
