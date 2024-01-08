using Baker.EntityLayer.Abstract;

namespace Baker.EntityLayer.Concrete
{
    public class Category : IMongoBaseEntity
    {
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public string? CategoryImage { get; set; }
        public bool IsHome { get; set; }
    }
}