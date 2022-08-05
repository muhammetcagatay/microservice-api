using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Movie.API.Models.Base;

namespace Movie.API.Models.Entities
{
    public class Comment : IEntity
    {
        [BsonRepresentation(BsonType.String)]
        public string FilmId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [BsonIgnore]
        public Film Film { get; set; }
    }
}
