using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Movie.API.Models.Settings;

namespace Movie.API.Data
{
    public class MongoDataContext : IMongoDataContext
    {
        private readonly IMongoDatabase _database;
        private readonly MongoClient _client;
        public IMongoDatabase database { get { return _database; }}
        public MongoClient client { get { return _client; } }
        IMongoDatabase IMongoDataContext.database { get { return _database; } set { } }
        MongoClient IMongoDataContext.client { get { return _client; } set { } }
        public MongoDataContext(IOptions<MongoDbSettings> configuration)
        {
            _client = new MongoClient(configuration.Value.ConnectionString);
            _database = _client.GetDatabase(configuration.Value.DatabaseName);
        }
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }
    }
}
