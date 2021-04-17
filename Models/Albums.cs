using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicpolitan.Models
{
    public class Albums
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Songs> Songs { get; set; }
    }
}
