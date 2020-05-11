using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadiAPI.Models
{
    public class OptionsProduct
    {
        public int OptionsId { get; set; }
        public Options Options { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
