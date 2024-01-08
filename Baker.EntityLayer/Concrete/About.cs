using Baker.EntityLayer.Abstract;

namespace Baker.EntityLayer.Concrete
{
    public class About : IMongoBaseEntity
    {
        public string? AboutTitle { get; set; }
        public string? AboutSubTitle { get; set; }
        public string? AboutDescription1 { get; set; }
        public string? AboutDescription2 { get; set; }
        public string? AboutImage1 { get; set; }
        public string? AboutImage2 { get; set; }
    }
}