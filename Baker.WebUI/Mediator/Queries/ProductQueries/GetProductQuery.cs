using Baker.WebUI.Mediator.Results.ProductResults;
using MediatR;

namespace Baker.WebUI.Mediator.Queries.ProductQueries
{
    public class GetProductQuery : IRequest<List<GetProductQueryResult>>
    {
    }
}