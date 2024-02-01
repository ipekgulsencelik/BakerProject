namespace Baker.WebUI.CQRS.Commands.ServiceCommands
{
    public class ChangeServiceStatusCommand
    {
        public string ServiceID { get; set; }
        public bool Status { get; set; }
    }
}