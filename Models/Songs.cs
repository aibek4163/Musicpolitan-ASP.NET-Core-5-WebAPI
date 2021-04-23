using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicpolitan.Models
{
    public class Songs
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Duration { get; set; }
        public string Image { get; set; }
        public int Rating { get; set; }
        public Genre Genre { get; set; }
        public Artists Artists { get; set; }
        public Albums Albums { get; set; }
    }
}
