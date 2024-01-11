using Baker.EntityLayer.Abstract;
using MongoDB.Bson.Serialization.Attributes;

namespace Baker.EntityLayer.Concrete
{
    public class SocialMedia : IMongoBaseEntity
    {
        public string? Icon { get; set; }
        public string? URL { get; set; }
        public bool IsHome { get; set; }

        public string? TeamID { get; set; }

        [BsonIgnore]
        public Team? Team { get; set; }

        public string? ContactID { get; set; }

        [BsonIgnore]
        public Contact? Contact { get; set; }
    }
}