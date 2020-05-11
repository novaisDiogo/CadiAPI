using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadiAPI.Models
{
    public class CashierOrder
    {
        public int Id { get; set; }
        public int CashierId { get; set; }
        public Cashier Cashier { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
