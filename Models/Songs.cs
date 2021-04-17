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
        public Genre Genre { get; set; }
    }
}
