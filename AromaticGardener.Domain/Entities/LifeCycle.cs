using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AromaticGardener.Domain.Entities
{
    public class LifeCycle
    {
        public int Id { get; set; }
        [Display(Name = "Life Cycle")]
        public required string Cycle { get; set; }
    }
}
