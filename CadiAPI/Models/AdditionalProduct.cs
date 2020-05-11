using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadiAPI.Models
{
    public class AdditionalProduct
    {
        public int AdditionalId { get; set; }
        public Additional Additional { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
