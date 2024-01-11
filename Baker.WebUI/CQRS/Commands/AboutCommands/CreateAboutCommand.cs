namespace Baker.WebUI.CQRS.Commands.AboutCommands
{
    public class CreateAboutCommand
    {
        public string? AboutTitle { get; set; }
        public string? AboutSubTitle { get; set; }
        public string? AboutDescription1 { get; set; }
        public string? AboutDescription2 { get; set; }
        public string? AboutImage1 { get; set; }
        public string? AboutImage2 { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}