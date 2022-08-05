using Movie.API.Models.Entities;

namespace Movie.API.Data.Repositories.Actors
{
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        public ActorRepository(IMongoDataContext context) : base(context)
        {
        }
    }
}
