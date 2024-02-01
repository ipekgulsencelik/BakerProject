using Baker.WebUI.Mediator.Results.CategoryResults;
using MediatR;

namespace Baker.WebUI.Mediator.Queries.CategoryQueries
{
    public class GetCategoryQuery : IRequest<List<GetCategoryQueryResult>>
    {
    }
}