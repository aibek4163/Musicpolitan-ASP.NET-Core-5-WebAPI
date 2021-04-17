using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicpolitan.Models
{
    public class Artists
    {
        public long Id { get; set; }
        public string Nickname { get; set; }
        public List<Songs> Songs { get; set; }
        public List<Albums> Albums { get; set; }
    }
}
