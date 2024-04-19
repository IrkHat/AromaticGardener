namespace AromaticGardener.Domain.Entities
{
    public class Herb
    {
        public int Id { get; set; }
        public required string CommonName { get; set; }
        public string? Description { get; set; }
        public string? Bloom { get; set; }
        public string? BestSoilType { get; set; }
        public required double SoilPhMin { get; set; }
        public required double SoilPhMax { get; set; }
        public required string Watering { get; set; }
        public required string Insulation { get; set; }
        public required string GrowthHabit { get; set; }
        public required string LifeCycle { get; set; }
        public required string Kingdom { get; set; }
        public string? Subkingdom { get; set; }
        public string? Superdivision { get; set; }
        public required string Division { get; set; }
        public required string Class { get; set; }
        public string? Subclass { get; set; }
        public required string Order { get; set; }
        public required string Family { get; set; }
        public required string Genus { get; set; }
        public required string Species { get; set; }
        public  string? ImageUrl { get; set; }


    }
}
