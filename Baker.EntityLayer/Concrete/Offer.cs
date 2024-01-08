using Baker.EntityLayer.Abstract;

namespace Baker.EntityLayer.Concrete
{
    public class Offer : IMongoBaseEntity
    {
        public string? OfferTitle { get; set; }
        public string? OfferSubTitle { get; set; }
        public string? OfferDescription { get; set; }
        public string? OfferImage1 { get; set; }
        public string? OfferImage2 { get; set; }
    }
}