using Baker.EntityLayer.Abstract;

namespace Baker.EntityLayer.Concrete
{
    public class Contact : IMongoBaseEntity
    {
        public string? Title { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
    }
}