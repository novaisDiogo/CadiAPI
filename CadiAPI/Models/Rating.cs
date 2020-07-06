using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadiAPI.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int Food { get; set; }
        public int Drinks { get; set; }
        public int Ambiance { get; set; }
        public int Service { get; set; }
    }
}
