using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Movie.API.Models.Base;
using System.Collections.Generic;

namespace Movie.API.Models.Entities
{
    public class Actor : IEntity
    {
        public Actor()
        {
            FilmsId = new List<string>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDayDate { get; set; } = DateTime.Now;
        [BsonRepresentation(BsonType.ObjectId)]
        public List<string> FilmsId { get; set; }
    }
}
