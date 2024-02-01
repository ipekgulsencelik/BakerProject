using MediatR;

namespace Baker.WebUI.Mediator.Commands.TestimonialCommands
{
    public class ChangeTestimonialStatusCommand : IRequest
    {
        public string Id { get; set; }
        public bool Status { get; set; }

        public ChangeTestimonialStatusCommand(string id)
        {
            Id = id;
        }
    }
}
