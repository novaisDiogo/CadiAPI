using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CadiAPI.Models
{
    public class Category
    {
        public int? Id { get; set; }
        public string Description { get; set; }
        public ICollection<CategoryProduct> CategoryProducts { get; set; }
        public Category()
        {
            CategoryProducts = new Collection<CategoryProduct>();
        }
    }
}
