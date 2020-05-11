using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadiAPI.Models
{
    public class OrderItem
    {
        public int? OrderItemId { get; set; }
        public int Quantity { get; set; }
        public double Value { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int? OptionsId { get; set; }
        public Options Options { get; set; }
        public int? AdditionalId { get; set; }
        public Additional Additional { get; set; }
    }
}
