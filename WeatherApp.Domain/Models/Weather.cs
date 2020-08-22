using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace WeatherApp.Domain
{
    public class Weather
    {
        [Key]
        public int weather_Id { get; set; }
        [JsonProperty("id")]
        public int condition { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public DateTime date { get; set; }
    }
}
