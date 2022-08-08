using Movie.API.Models.Base;
using Movie.API.Models.Request.Films;
using Movie.API.Models.Response.Films;

namespace Movie.API.Services.Films
{
    public interface IFilmService
    {
        Task<Response<ResponseGetFilm>> GetByIdAsync(string id);
        Task<Response<IEnumerable<ResponseGetFilm>>> GetAllAsync();
        Task<Response<ResponseGetFilmWithActors>> GetFilmWithActors(string id);
        Task<Response<ResponseCreateFilm>> CreateAsync(RequestFilm requestFilm);
        Task<Response<ResponseFilm>> UpdateAsync(string id, RequestFilm requestFilm);
        Task<Response<ResponseFilm>> RemoveAsync(string id);
    }
}
