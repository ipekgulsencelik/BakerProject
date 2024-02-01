using MediatR;

namespace Baker.WebUI.Mediator.Commands.ProductCommands
{
    public class RemoveProductCommand : IRequest
    {
        public string Id { get; set; }

        public RemoveProductCommand(string id)
        {
            Id = id;
        }
    }
}