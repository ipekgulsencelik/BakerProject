using MediatR;

namespace Baker.WebUI.Mediator.Commands.TeamCommands
{
    public class CreateTeamCommand : IRequest
    {
        public string? TeamFullName { get; set; }
        public string? TeamImageURL { get; set; }
        public string? TeamTitle { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
        public bool IsHome { get; set; }
    }
}