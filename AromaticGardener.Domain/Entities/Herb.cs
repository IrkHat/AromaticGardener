using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AromaticGardener.Domain.Entities
{
    public class Herb
    {
        public int Id { get; set; }
        [Display(Name = "Common Name")]
        public required string CommonName { get; set; }
        [Display(Name = "Scientific Name")]
        public required string ScientificName { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }
        [Display(Name = "Blooms In")]
        public string? Bloom { get; set; }
        [Display(Name = "Best Substrate Type")]
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

        [ForeignKey("GrowthHabit")]
        public required int GrowthHabitId { get; set; }
        [ValidateNever]
        public GrowthHabit GrowthHabit { get; set; } = null!;

        [ForeignKey("LifeCycle")]
        public required int LifeCycleId { get; set; }
		[ValidateNever]
		public LifeCycle LifeCycle { get; set; } = null!;

        [Display(Name = "Image Url")]
        public  string? ImageUrl { get; set; }


    }
}
