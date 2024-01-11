namespace Baker.WebUI.CQRS.Commands.ServiceCommands
{
    public class RemoveServiceCommand
    {
        public string Id { get; set; }

        public RemoveServiceCommand(string id)
        {
            Id = id;
        }
    }
}