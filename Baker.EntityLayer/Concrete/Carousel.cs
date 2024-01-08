using Baker.EntityLayer.Abstract;

namespace Baker.EntityLayer.Concrete
{
    public class Carousel : IMongoBaseEntity
    {
        public string? ImageURL { get; set; }
        public string? Title { get; set; }
        public string? MainTitle { get; set; }
        public string? Description { get; set; }
        public bool IsHome { get; set; }
    }
}