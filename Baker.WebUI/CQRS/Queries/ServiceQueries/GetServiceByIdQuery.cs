namespace Baker.WebUI.CQRS.Queries.ServiceQueries
{
    public class GetServiceByIdQuery
    {
        public string Id { get; set; }

        public GetServiceByIdQuery(string id)
        {
            Id = id;
        }
    }
}