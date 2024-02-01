namespace Baker.DTO.DTOs.SocialMediaDTOs
{
	public class CreateSocialMediaDTO
	{
		public string? Icon { get; set; }
		public string? URL { get; set; }
		public bool IsHome { get; set; }

		public DateTime CreatedAt { get; set; }
		public bool Status { get; set; }
	}
}