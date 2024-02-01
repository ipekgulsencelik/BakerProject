namespace Baker.WebUI.Mediator.Results.CategoryResults
{
    public class GetCategoryByIdQueryResult
    {
        public string ID { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public string? CategoryImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
        public bool IsHome { get; set; }
    }
}