
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
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

        //[DataType(DataType.Date)]
        //[JsonConverter(typeof(JsonDateTimeConverter))]
        //[Required]
        public DateTime Date { get; set; }
    }
}
