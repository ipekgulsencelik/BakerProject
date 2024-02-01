using MediatR;

namespace Baker.WebUI.Mediator.Commands.CategoryCommands
{
    public class CreateCategoryCommand : IRequest
    {
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public string? CategoryImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
        public bool IsHome { get; set; }
    }
}