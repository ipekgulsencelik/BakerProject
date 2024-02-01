using Baker.EntityLayer.Abstract;
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

		public string? CategoryName { get; set; }
    }
}