using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicpolitan.Models
{
    public class Albums
    {
        public long id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public DateTime date { get; set; }
        public List<Songs> songs { get; set; }
        public Artists artists { get; set; }
    }
}
