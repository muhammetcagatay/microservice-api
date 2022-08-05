using Movie.API.Models.Entities;

namespace Movie.API.Data.Repositories.Comments
{
    public class CommentRepository : GenericRepository<Comment>, ICommentsRepository
    {
        public CommentRepository(IMongoDataContext context) : base(context)
        {
        }
    }
}
