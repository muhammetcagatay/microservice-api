using Movie.API.Models.Entities;

namespace Movie.API.Data.Repositories.Comments
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(IMongoDataContext context) : base(context)
        {
        }
    }
}
