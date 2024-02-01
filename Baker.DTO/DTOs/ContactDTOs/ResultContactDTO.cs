namespace Baker.DTO.DTOs.ContactDTOs
{
	public class ResultContactDTO
	{
		public string ID { get; set; }
		public string? Title { get; set; }
		public string? Address { get; set; }
		public string? PhoneNumber { get; set; }
		public string? EmailAddress { get; set; }
		public DateTime CreatedAt { get; set; }
		public bool Status { get; set; }
	}
}