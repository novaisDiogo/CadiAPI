using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadiAPI.Models
{
    public class Order
    {
        public int? OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? TotalValue { get; set; }
        public int? OrderStatus { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public CashierOrder CashierOrder { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }

    }
}
