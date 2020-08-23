using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WeatherApp.Domain
{
    public class Root
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public List<Weather> weather { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        [JsonProperty("dt")]
        public int datetime { get; set; }
        public System sys { get; set; }
        public int timezone { get; set; }
        [JsonProperty("name")]
        public string cityname { get; set; }
    }
}
