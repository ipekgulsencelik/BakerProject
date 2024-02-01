using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Baker.WebUI.Mediator.Results.ProductResults
{
    public class GetProductByIdQueryResult
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public string? ProductImage { get; set; }
        public string? CategoryName { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
        public bool IsHome { get; set; }
    }
}