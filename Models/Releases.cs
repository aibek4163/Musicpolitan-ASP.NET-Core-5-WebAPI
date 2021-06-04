using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicpolitan.Models
{
    public class Releases
    {
        public long id { get; set; }
        public string title { get; set; }
        public string shortDescription { get; set; }
        public string text { get; set; }
        public string image { get; set; }
        public string banner_image { get; set; }
        public DateTime date { get; set; }
        public Artists artist { get; set; }
    }
}
