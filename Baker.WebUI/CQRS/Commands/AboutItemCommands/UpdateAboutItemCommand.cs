using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Baker.WebUI.CQRS.Commands.AboutItemCommands
{
    public class UpdateAboutItemCommand
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }
        public string? ItemName { get; set; }
        public string? AboutID { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
        public bool IsHome { get; set; }
    }
}