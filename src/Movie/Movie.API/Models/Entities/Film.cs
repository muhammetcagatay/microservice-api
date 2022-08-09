using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Movie.API.Models.Base;
using Movie.API.Models.Enums;

namespace Movie.API.Models.Entities
{
    public class Film : IEntity
    {
        public Film()
        {
            ActorsId = new List<string>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public Country Country { get; set; }
        public Language Language { get; set; }
        public int PublicationYear { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> ActorsId { get; set; }
    }

}
