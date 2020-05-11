using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadiAPI.Models
{
    public class UserStatus
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
