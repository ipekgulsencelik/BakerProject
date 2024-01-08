using Baker.EntityLayer.Abstract;

namespace Baker.EntityLayer.Concrete
{
    public class Gallery : IMongoBaseEntity
    {
        public string? ImageName { get; set; }
        public string? ImagePath { get; set; }
        public bool IsHome { get; set; }
    }
}