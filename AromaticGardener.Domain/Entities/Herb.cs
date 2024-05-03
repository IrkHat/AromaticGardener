using System.ComponentModel.DataAnnotations;

namespace AromaticGardener.Domain.Entities
{
    public class Herb
    {
        public int Id { get; set; }
        [Display(Name = "Common Name")]
        public required string CommonName { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Display(Name = "Blooms In")]
        public string? Bloom { get; set; }
        [Display(Name = "Best Soil Type")]
        public string? BestSoilType { get; set; }
        [Display(Name = "Minimum Soil pH")]
        [Range(0,14)]
        public required double SoilPhMin { get; set; }
        [Display(Name = "Maximum Soil pH")]
        [Range(0, 14)]
        public required double SoilPhMax { get; set; }
        [Display(Name = "Watering Frequency")]
        public required string Watering { get; set; }
        [Display(Name = "Insulation")]
        public required string Insulation { get; set; }
        [Display(Name = "Growth Habit")]
        public required string GrowthHabit { get; set; }
        [Display(Name = "Life Cycle")]
        public required string LifeCycle { get; set; }
        [Display(Name = "Image Url")]
        public  string? ImageUrl { get; set; }


    }
}
