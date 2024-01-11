namespace Baker.WebUI.CQRS.Commands.OfferCommands
{
    public class RemoveOfferCommand
    {
        public string Id { get; set; }

        public RemoveOfferCommand(string id)
        {
            Id = id;
        }
    }
}