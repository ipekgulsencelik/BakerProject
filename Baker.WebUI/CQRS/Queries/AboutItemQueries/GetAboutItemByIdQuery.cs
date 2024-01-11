namespace Baker.WebUI.CQRS.Queries.AboutItemQueries
{
    public class GetAboutItemByIdQuery
    {
        public string Id { get; set; }

        public GetAboutItemByIdQuery(string id)
        {
            Id = id;
        }
    }
}