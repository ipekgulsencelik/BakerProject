using Baker.EntityLayer.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Baker.EntityLayer.Concrete
{
    public class SocialMedia : IMongoBaseEntity
    {
        public string? Icon { get; set; }
        public string? URL { get; set; }
        public bool IsHome { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? TeamID { get; set; }

        [BsonIgnore]
        public Team Team { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? ContactID { get; set; }

        [BsonIgnore]
        public Contact Contact { get; set; }
    }
}