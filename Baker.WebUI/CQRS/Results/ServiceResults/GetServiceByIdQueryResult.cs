namespace Baker.WebUI.CQRS.Results.ServiceResults
{
    public class GetServiceByIdQueryResult
    {
        public string ServiceID { get; set; }
        public string? Icon { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? OfferID { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
        public bool IsHome { get; set; }
    }
}