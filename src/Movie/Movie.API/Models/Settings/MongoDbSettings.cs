namespace Movie.API.Models.Settings
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
