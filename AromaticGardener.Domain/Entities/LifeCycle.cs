using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AromaticGardener.Domain.Entities
{
    public class LifeCycle
    {
        public int Id { get; set; }
        public required string Cycle { get; set; }
    }
}
