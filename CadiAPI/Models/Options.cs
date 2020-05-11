using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadiAPI.Models
{
    public class Options
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public ICollection<OptionsProduct> OptionsProducts { get; set; }
    }
}
