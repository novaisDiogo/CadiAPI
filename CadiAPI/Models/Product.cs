using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CadiAPI.Models
{
    public class Product
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public double? Value { get; set; }
        public bool Status { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public ICollection<CategoryProduct> CategoryProducts { get; set; }
        public ICollection<OptionsProduct> OptionsProducts { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public Product()
        {
            CategoryProducts = new Collection<CategoryProduct>();
            OptionsProducts = new Collection<OptionsProduct>();
            OrderItems = new Collection<OrderItem>();
        }
    }
}
