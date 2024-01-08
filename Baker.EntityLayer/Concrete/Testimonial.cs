using Baker.EntityLayer.Abstract;

namespace Baker.EntityLayer.Concrete
{
    internal class Testimonial : IMongoBaseEntity
    {
        public string? TestimonialFullName { get; set; }
        public string? TestimonialComment { get; set; }
        public string? TestimonialImageURL { get; set; }
        public string? TestimonialTitle { get; set; }
        public bool IsHome { get; set; }
    }
}