using Movie.API.Models.Entities;

namespace Movie.API.Data.Repositories.Films
{
    public class FilmRepository : GenericRepository<Film>, IFilmRepository
    {
        public FilmRepository(IMongoDataContext context) : base(context)
        {
        }
    }
}
