using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Movie.API.Models.Base;

namespace Movie.API.Models.Entities
{
    public class Image : IEntity
    {
        public string URL { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string FilmId { get; set; }
    }
}
