namespace Baker.WebUI.CQRS.Commands.ServiceCommands
{
    public class CreateServiceCommand
    {
        public string? Icon { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? OfferID { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
        public bool IsHome { get; set; }
    }
}