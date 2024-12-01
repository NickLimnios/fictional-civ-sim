namespace fcs.api.Models
{
    public class Civilization
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Population { get; set; }
        public int CurrentYear { get; set; }
        public string? Climate { get; set; }
        public string? Culture { get; set; }
        public string? Technology { get; set; }
        public ICollection<Resource> Resources { get; set; } = [];
        public ICollection<Event> Events { get; set; } = [];
    }

}
