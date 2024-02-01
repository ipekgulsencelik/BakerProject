namespace Baker.DTO.DTOs.SocialMediaDTOs
{
	public class UpdateSocialMediaDTO
	{
		public string ID { get; set; }
		public string? Icon { get; set; }
		public string? URL { get; set; }
		public bool IsHome { get; set; }

		public DateTime CreatedAt { get; set; }
		public bool Status { get; set; }
	}
}
