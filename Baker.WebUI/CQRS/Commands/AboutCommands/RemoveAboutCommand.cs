namespace Baker.WebUI.CQRS.Commands.AboutCommands
{
    public class RemoveAboutCommand
    {
        public string Id { get; set; }
        
        public RemoveAboutCommand(string id)
        {
            Id = id;
        }        
    }
}