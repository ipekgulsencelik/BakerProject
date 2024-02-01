namespace Baker.WebUI.CQRS.Commands.ContactCommands
{
	public class UpdateContactCommand
	{
		public string ContactID { get; set; }
		public string? Title { get; set; }
		public string? Address { get; set; }
		public string? PhoneNumber { get; set; }
		public string? EmailAddress { get; set; }
		public DateTime CreatedAt { get; set; }
		public bool Status { get; set; }
	}
}