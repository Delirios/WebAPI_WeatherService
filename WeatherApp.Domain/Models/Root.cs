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
        public int RootId { get; set; }
        [JsonProperty("id")]
        public int city_Id { get; set; }

        [JsonProperty("coord")]
        public Coordinates coordinates { get; set; }
        public List<Weather> weather { get; set; }
        public Clouds clouds { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        [JsonProperty("dt")]
        public int update_time { get; set; }
        [JsonProperty("sys")]
        public System system { get; set; }
        public int timezone { get; set; }
        [JsonProperty("name")]
        public string cityname { get; set; }
    }
}
