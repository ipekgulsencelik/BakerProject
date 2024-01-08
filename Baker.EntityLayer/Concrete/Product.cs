using Baker.EntityLayer.Abstract;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Baker.EntityLayer.Concrete
{
    public class Product : IMongoBaseEntity
    {
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public string? ProductImage { get; set; }
        public bool IsHome { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryID { get; set; }

        [BsonIgnore]
        public Category Category { get; set; }
    }
}