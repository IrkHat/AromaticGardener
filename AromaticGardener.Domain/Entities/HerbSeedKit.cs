using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AromaticGardener.Domain.Entities
{
    public class HerbSeedKit
    {
        public int Id { get; set; }
        [ForeignKey("Herb")]
        public int HerbId { get; set; }
        public Herb Herb { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }

    }
}
