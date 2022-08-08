using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Movie.API.Models.Base;
using Movie.API.Models.Enums;

namespace Movie.API.Models.Entities
{
    public class Film : IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        [BsonRepresentation(BsonType.Int64)]
        public Country Country { get; set; }
        [BsonRepresentation(BsonType.Int64)]
        public Language Language { get; set; }
        public int PublicationYear { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> ActorsId { get; set; }
    }

}
