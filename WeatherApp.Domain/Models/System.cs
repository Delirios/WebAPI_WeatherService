using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Newtonsoft.Json;

namespace WeatherApp.Domain
{
    public class System
    {
        [Key]
        public int Id { get; set; }
        [JsonProperty("id")]
        public int internal_parameter { get; set; }
        public int type { get; set; }
        public double message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }
}
