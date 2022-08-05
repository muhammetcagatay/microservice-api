using Movie.API.Models.Entities;

namespace Movie.API.Data.Repositories.Images
{
    public class ImageRepository : GenericRepository<Image>, IImageRepository
    {
        public ImageRepository(IMongoDataContext context) : base(context)
        {
        }
    }
}
