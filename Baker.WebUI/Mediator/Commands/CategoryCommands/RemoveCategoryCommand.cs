using MediatR;

namespace Baker.WebUI.Mediator.Commands.CategoryCommands
{
    public class RemoveCategoryCommand : IRequest
    {
        public string Id { get; set; }

        public RemoveCategoryCommand(string id)
        {
            Id = id;
        }
    }
}