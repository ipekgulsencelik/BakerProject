namespace Baker.WebUI.CQRS.Queries.AboutQueries
{
    public class GetAboutByIdQuery
    {
        public string Id { get; set; }

        public GetAboutByIdQuery(string id)
        {
            Id = id;
        }
    }
}