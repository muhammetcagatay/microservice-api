using Movie.API.Models.Entities;

namespace Movie.API.Data.Repositories.Directors
{
    public class DirectorRepository : GenericRepository<Director>, IDirectorRepository
    {
        public DirectorRepository(IMongoDataContext context) : base(context)
        {
        }
    }
}
