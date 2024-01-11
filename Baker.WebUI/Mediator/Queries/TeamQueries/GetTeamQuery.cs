using Baker.WebUI.Mediator.Results.TeamResults;
using MediatR;

namespace Baker.WebUI.Mediator.Queries.TeamQueries
{
    public class GetTeamQuery : IRequest<List<GetTeamQueryResult>>
    {
    }
}