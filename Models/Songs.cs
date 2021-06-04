using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicpolitan.Models
{
    public class Songs
    {
        public long id { get; set; }
        public string name { get; set; }
        public double duration { get; set; }
        public string image { get; set; }
        public int rating { get; set; }
        public Genre genre { get; set; }
        public Artists artist { get; set; }
    }
}
