namespace Baker.WebUI.CQRS.Commands.AboutItemCommands
{
    public class CreateAboutItemCommand
    {
        public string? ItemName { get; set; }
        public string? AboutID { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
        public bool IsHome { get; set; }
    }
}