namespace fcs.api.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public int CivilizationId { get; set; }
        public required string Name { get; set; } 
        public int Quantity { get; set; } 

        public Civilization Civilization { get; set; }
    }

}
