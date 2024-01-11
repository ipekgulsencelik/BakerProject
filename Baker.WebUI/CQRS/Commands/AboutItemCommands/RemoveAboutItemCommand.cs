namespace Baker.WebUI.CQRS.Commands.AboutItemCommands
{
    public class RemoveAboutItemCommand
    {
        public string Id { get; set; }

        public RemoveAboutItemCommand(string id)
        {
            Id = id;
        }
    }
}