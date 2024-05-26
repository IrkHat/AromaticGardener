using System.ComponentModel.DataAnnotations;

namespace AromaticGardener.Domain.Entities
{
    public class GrowthHabit
    {
        public int Id { get; set; }
        [Display(Name = "Growth Habit")]
        public required String Habit { get; set; }

    }
}
