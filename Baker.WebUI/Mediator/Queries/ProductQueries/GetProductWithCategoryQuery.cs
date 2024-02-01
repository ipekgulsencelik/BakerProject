using Baker.WebUI.Mediator.Results.ProductResults;
using MediatR;

namespace Baker.WebUI.Mediator.Queries.ProductQueries
{
    public class GetProductWithCategoryQuery : IRequest<List<GetProductWithCategoryQueryResult>>
    {
    }
}