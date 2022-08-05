using Movie.API.Models.Base;
using Movie.API.Models.Entities;
using Movie.API.Models.Request.Actors;
using Movie.API.Models.Response.Actors;

namespace Movie.API.Services.Actors
{
    public interface IActorService
    {
        Task<Response<ResponseGetActor>> GetByIdAsync(string id);
        Task<Response<IEnumerable<ResponseGetActor>>> GetAllAsync();
        Task<Response<ResponseGetActorWithFilms>> GetActorWithFilms(string id);
        Task<Response<ResponseCreateActor>> CreateAsync(RequestCreateActor requestCreateActor);
        Task<Response<ResponseUpdateActor>> UpdateAsync(string id, RequestUpdateActor requestUpdateActor);
        Task<Response<ResponseDeleteActor>> RemoveAsync(string id);
    }
}
