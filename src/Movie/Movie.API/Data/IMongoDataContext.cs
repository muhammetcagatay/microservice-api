using MongoDB.Driver;

namespace Movie.API.Data
{
    public interface IMongoDataContext
    {
        IMongoDatabase database { get; set; }
        MongoClient client { get; set; }
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
