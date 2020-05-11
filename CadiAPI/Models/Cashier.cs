using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadiAPI.Models
{
    public class Cashier
    {
        public int Id { get; set; }
        public double InitialValue { get; set; }
        public double FinalValue { get; set; }
        public DateTime Data { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<CashierOrder> CashierOrders { get; set; } = new List<CashierOrder>();
    }
}
