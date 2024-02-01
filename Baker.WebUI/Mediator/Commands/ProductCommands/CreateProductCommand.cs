using MediatR;

namespace Baker.WebUI.Mediator.Commands.ProductCommands
{
    public class CreateProductCommand : IRequest
    {
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public string? ProductImage { get; set; }
        public string? CategoryName { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
        public bool IsHome { get; set; }
    }
}