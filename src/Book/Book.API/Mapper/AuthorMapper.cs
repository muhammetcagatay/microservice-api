using AutoMapper;
using Book.API.Models.Entities;
using Book.API.Models.Request.Authors;
using Book.API.Models.Response.Authors;

namespace Book.API.Mapper
{
    public class AuthorMapper : Profile
    {
        public AuthorMapper()
        {
            CreateMap<Author, AuthorResponse>().ReverseMap();
            CreateMap<Author, AuthorRequest>().ReverseMap();
            CreateMap<Author, AuthorWithBooksResponse>().ReverseMap();
        }
    }
}
