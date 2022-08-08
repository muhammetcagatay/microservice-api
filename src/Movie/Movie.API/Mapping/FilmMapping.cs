using AutoMapper;
using Movie.API.Models.Entities;
using Movie.API.Models.Request.Films;
using Movie.API.Models.Response.Films;

namespace Movie.API.Mapping
{
    public class FilmMapping : Profile
    {
        public FilmMapping()
        {
            CreateMap<Film, ResponseFilm>().ReverseMap();
            CreateMap<Film, ResponseCreateFilm>().ReverseMap();
            CreateMap<Film, ResponseGetFilm>().ReverseMap();
            CreateMap<Film, ResponseGetFilmWithActors>().ReverseMap();
            CreateMap<Film, RequestFilm>().ReverseMap();
        }
    }
}
