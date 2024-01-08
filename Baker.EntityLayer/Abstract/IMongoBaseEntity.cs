using MongoDB.Bson.Serialization.Attributes;

namespace Baker.EntityLayer.Abstract
{
    public abstract class IMongoBaseEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ID { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [BsonRepresentation(MongoDB.Bson.BsonType.Boolean)]
        public bool Status { get; set; }
    }
}