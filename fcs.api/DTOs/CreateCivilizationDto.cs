namespace fcs.api.DTOs
{
    public class CreateCivilizationDto
    {
        public required string Name { get; set; }
        public int Population { get; set; }
        public int CurrentYear { get; set; } = 0;
        public Dictionary<string, int>? Resources { get; set; }
        public string? Climate { get; set; }
        public string? Culture { get; set; }
        public string? Technology { get; set; }
    }

}
