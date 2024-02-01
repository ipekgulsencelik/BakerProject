namespace Baker.WebUI.CQRS.Results.AboutItemResults
{
    public class GetAboutItemByIdQueryResult
    {
        public string ID { get; set; }
        public string? ItemName { get; set; }
        public string? AboutID { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
        public bool IsHome { get; set; }        
    }
}