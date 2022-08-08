using AutoMapper;
using Movie.API.Models.Entities;
using Movie.API.Models.Request.Categories;
using Movie.API.Models.Request.Films;
using Movie.API.Models.Response.Categories;
using Movie.API.Models.Response.Films;

namespace Movie.API.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<Category, ResponseCategory>().ReverseMap();
            CreateMap<Category, ResponseCreateCategory>().ReverseMap();
            CreateMap<Category, ResponseGetCategory>().ReverseMap();
            CreateMap<Category, ResponseGetCategoryWithFilms>().ReverseMap();
            CreateMap<Category, RequestCategory>().ReverseMap();
        }
    }
}
