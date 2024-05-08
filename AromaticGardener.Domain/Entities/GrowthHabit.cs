using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AromaticGardener.Domain.Entities
{
    public class GrowthHabit
    {
        public int Id { get; set; }
        [Display(Name = "Growth Habit")]
        public required String Habit { get; set; }

    }
}
