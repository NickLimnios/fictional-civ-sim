namespace fcs.api.DTOs
{
    public class CivilizationResponseDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Population { get; set; }
        public int CurrentYear { get; set; }
        public List<ResourceDto>? Resources { get; set; }
        public List<EventDto>? Events { get; set; }
    }

}
