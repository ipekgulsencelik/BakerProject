namespace Baker.DTO.DTOs.SubscribeDTOs
{
    public class ResultSubscribeDTO
    {
        public string ID { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}