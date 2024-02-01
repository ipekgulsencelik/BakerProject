namespace Baker.WebUI.CQRS.Commands.ServiceCommands
{
    public class ChangeHomeStatusCommand
    {
        public string Id { get; set; }
        public bool IsHome { get; set; }

        public ChangeHomeStatusCommand(string id)
        {
            Id = id;
        }
    }
}