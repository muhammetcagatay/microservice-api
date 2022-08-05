using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Movie.API.Models.Base;

namespace Movie.API.Models.Entities
{
    public class Comment : IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string FilmId { get; set; }
    }
}
