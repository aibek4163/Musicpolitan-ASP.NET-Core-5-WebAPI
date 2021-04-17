using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicpolitan.Models
{
    public class Articles
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Short_description {get;set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public string BannerImage { get; set; }
        public DateTime Date { get; set; }
        public Users Users { get; set; }
    }
}
