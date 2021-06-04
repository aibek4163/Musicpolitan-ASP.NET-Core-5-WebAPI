using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicpolitan.Models
{
    public class Users
    {
        public long id { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
        public string password { get; set; }
    }
}
