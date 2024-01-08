using Baker.EntityLayer.Abstract;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Baker.EntityLayer.Concrete
{
    public class AboutItem : IMongoBaseEntity
    {
        public string Name { get; set; }
        public bool IsHome { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string AboutID { get; set; }

        [BsonIgnore]
        public About About { get; set; }
    }
}