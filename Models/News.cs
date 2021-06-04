
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
        public long id { get; set; }
        public string title { get; set; }
        public string shortDescription { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string banner_image { get; set; }

        //[DataType(DataType.Date)]
        //[JsonConverter(typeof(JsonDateTimeConverter))]
        //[Required]
        public DateTime date { get; set; }
    }
}
