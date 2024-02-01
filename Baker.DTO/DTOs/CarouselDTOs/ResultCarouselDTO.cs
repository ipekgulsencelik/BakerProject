﻿namespace Baker.DTO.DTOs.CarouselDTOs
{
	public class ResultCarouselDTO
	{
		public string ID { get; set; }
		public string? ImageURL { get; set; }
		public string? Title { get; set; }
		public string? MainTitle { get; set; }
		public string? Description { get; set; }
		public DateTime CreatedAt { get; set; }
		public bool Status { get; set; }
		public bool IsHome { get; set; }
	}
}