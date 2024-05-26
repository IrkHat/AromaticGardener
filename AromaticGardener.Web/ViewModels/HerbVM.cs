using AromaticGardener.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AromaticGardener.Web.ViewModels
{
    public class HerbVM
    {
        public Herb Herb { get; set; } = null!;
        [ValidateNever]
        public IEnumerable<SelectListItem>? LifeCycleList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? GrowthHabitList { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
