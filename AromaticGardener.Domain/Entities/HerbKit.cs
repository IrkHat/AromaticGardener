using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AromaticGardener.Domain.Entities
{
    public class HerbKit
    {
        public int Id { get; set; }


        [ForeignKey("Herb")]
        public required int HerbId { get; set; }
        [ValidateNever]
        public Herb Herb { get; set; } = null!;



		[Display(Name = "Kit Name")]
		public required string Name { get; set; }
		[Display(Name = "Brief Description")]
		public string? Description { get; set; }
		[Display(Name = "Price per Unit")]
		public double Price { get; set; }
		[Display(Name = "Units in Stock")]
		public int Stock { get; set; }

    }
}
