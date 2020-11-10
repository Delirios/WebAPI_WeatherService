using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace WeatherApp.Domain
{
    public class Clouds
    {
        [Key]
        public int CloudId { get; set; }
        [JsonProperty("all")]
        public int cloudiness { get; set; }
    }
}
