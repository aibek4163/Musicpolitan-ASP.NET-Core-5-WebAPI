using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicpolitan.Models
{
    public class News
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Short_description { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Banner_image { get; set; }
        public DateTime Date { get; set; }
    }
}
