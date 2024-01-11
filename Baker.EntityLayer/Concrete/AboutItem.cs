using Baker.EntityLayer.Abstract;
using MongoDB.Bson.Serialization.Attributes;

namespace Baker.EntityLayer.Concrete
{
    public class AboutItem : IMongoBaseEntity
    {
        public string? ItemName { get; set; }
        public bool IsHome { get; set; }

        public string? AboutID { get; set; }

        [BsonIgnore]
        public About? About { get; set; }
    }
}