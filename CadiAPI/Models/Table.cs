using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadiAPI.Models
{
    public class Table
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
