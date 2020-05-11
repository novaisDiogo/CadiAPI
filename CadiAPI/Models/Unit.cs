using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadiAPI.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Product { get; set; } = new List<Product>();
    }
}
