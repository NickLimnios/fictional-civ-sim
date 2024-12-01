namespace fcs.api.Models
{
    public class Event
    {
        public int Id { get; set; }
        public int CivilizationId { get; set; }
        public int Year { get; set; }
        public string? Description { get; set; }

        public Civilization Civilization { get; set; }
    }

}
