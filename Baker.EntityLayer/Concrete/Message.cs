using Baker.EntityLayer.Abstract;

namespace Baker.EntityLayer.Concrete
{
    public class Message : IMongoBaseEntity
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Content { get; set; }
    }
}