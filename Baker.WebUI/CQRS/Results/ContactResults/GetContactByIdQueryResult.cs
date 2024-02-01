namespace Baker.WebUI.CQRS.Results.ContactResults
{
	public class GetContactByIdQueryResult
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