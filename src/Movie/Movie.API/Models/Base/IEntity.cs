using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Movie.API.Models.Base
{
    public class IEntity
    {
        public IEntity()
        {
            CreateDate = DateTime.Now;
            IsDelete = false;
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreateDate { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime UpdateDate { get; set; }

        [BsonRepresentation(BsonType.Boolean)]
        public bool IsDelete { get; set; }
    }
}
