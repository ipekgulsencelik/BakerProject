using Baker.WebUI.Mediator.Results.ProductResults;
using MediatR;

namespace Baker.WebUI.Mediator.Queries.ProductQueries
{
    public class GetProductByIdQuery : IRequest<GetProductByIdQueryResult>
    {
        public string Id { get; set; }

        public GetProductByIdQuery(string id)
        {
            Id = id;
        }
    }
}