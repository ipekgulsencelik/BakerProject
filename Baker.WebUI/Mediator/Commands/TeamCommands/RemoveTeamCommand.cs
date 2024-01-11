using MediatR;

namespace Baker.WebUI.Mediator.Commands.TeamCommands
{
    public class RemoveTeamCommand : IRequest
    {
        public string Id { get; set; }

        public RemoveTeamCommand(string id)
        {
            Id = id;
        }
    }
}