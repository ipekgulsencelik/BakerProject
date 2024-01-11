namespace Baker.WebUI.CQRS.Queries.OfferQueries
{
    public class GetOfferByIdQuery
    {
        public string Id { get; set; }

        public GetOfferByIdQuery(string id)
        {
            Id = id;
        }
    }
}