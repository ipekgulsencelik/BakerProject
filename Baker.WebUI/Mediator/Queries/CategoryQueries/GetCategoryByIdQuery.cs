using Baker.WebUI.Mediator.Results.CategoryResults;
using MediatR;

namespace Baker.WebUI.Mediator.Queries.CategoryQueries
{
    public class GetCategoryByIdQuery : IRequest<GetCategoryByIdQueryResult>
    {
        public string Id { get; set; }

        public GetCategoryByIdQuery(string id)
        {
            Id = id;
        }
    }
}
