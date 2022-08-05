using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Movie.API.Models.Base;

namespace Movie.API.Models.Entities
{
    public class Actor : IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDayDate { get; set; } = DateTime.Now;
        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> Films { get; set; }
    }
}
