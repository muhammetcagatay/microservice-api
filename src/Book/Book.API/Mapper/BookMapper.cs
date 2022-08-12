using AutoMapper;
using Book.API.Models.Entities;
using Book.API.Models.Request.Authors;
using Book.API.Models.Request.Books;
using Book.API.Models.Response.Authors;
using Book.API.Models.Response.Books;

namespace Book.API.Mapper
{
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<BookEntity, BookResponse>().ReverseMap();
            CreateMap<BookEntity, BookRequest>().ReverseMap();
        }
    }
}
