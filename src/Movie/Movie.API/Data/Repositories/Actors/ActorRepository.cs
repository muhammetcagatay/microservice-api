using MongoDB.Driver;
using Movie.API.Models.Entities;

namespace Movie.API.Data.Repositories.Actors
{
    public class ActorRepository : GenericRepository<Actor>, IActorRepository
    {
        private readonly IMongoDataContext _context;
        private readonly IMongoCollection<Actor> _collection;
        public ActorRepository(IMongoDataContext context) : base(context)
        {
            _context = context;
            _collection = _context.GetCollection<Actor>(typeof(Actor).Name);
        }
        public async Task AddFilmAsync(string id, string film)
        {
            var actor = await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

            actor.FilmsId.Add(film);

            await _collection.ReplaceOneAsync(x => x.Id == id, actor);
        }
    }
}
