using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicpolitan.Models
{
    public class Comment
    {
        public long id { get; set; }
        public string  comment { get; set; }
        public DateTime Date { get; set; }
        public Users author { get; set; }
        public News news { get; set; }
    }
}
