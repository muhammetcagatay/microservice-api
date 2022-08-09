using Movie.API.Models.Entities;

namespace Movie.API.Data.Repositories.Actors
{
    public interface IActorRepository : IRepository<Actor>
    {
        Task AddFilmAsync(string id,string film);
        Task RemoveFilmAsync(string id,string film);
    }
}
