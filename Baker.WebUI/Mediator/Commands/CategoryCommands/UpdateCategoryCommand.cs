using MediatR;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Baker.WebUI.Mediator.Commands.CategoryCommands
{
    public class UpdateCategoryCommand : IRequest
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public string? CategoryImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
        public bool IsHome { get; set; }
    }
}