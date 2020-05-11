using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadiAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PassHash { get; set; }
        public byte ResetPass { get; set; }
        public int UserStatusId { get; set; }
        public UserStatus UserStatus { get; set; }
    }
}
