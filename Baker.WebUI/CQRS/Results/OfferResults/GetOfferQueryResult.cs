namespace Baker.WebUI.CQRS.Results.OfferResults
{
    public class GetOfferQueryResult
    {
        public string OfferID { get; set; }
        public string? OfferTitle { get; set; }
        public string? OfferSubTitle { get; set; }
        public string? OfferDescription { get; set; }
        public string? OfferImage1 { get; set; }
        public string? OfferImage2 { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}