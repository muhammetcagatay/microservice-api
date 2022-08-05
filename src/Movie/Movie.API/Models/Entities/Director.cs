using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Movie.API.Models.Base;
using Movie.API.Models.Enums;

namespace Movie.API.Models.Entities
{
    public class Director : IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        [BsonRepresentation(BsonType.String)]
        public Country Country { get; set; }

    }
}
