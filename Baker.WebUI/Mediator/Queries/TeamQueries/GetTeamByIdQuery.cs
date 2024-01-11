using Baker.WebUI.Mediator.Results.TeamResults;
using MediatR;

namespace Baker.WebUI.Mediator.Queries.TeamQueries
{
    public class GetTeamByIdQuery : IRequest<GetTeamByIdQueryResult>
    {
        public string Id { get; set; }

        public GetTeamByIdQuery(string id)
        {
            Id = id;
        }
    }
}