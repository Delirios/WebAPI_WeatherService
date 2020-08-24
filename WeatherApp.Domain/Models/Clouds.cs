using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace WeatherApp.Domain
{
    public class Clouds
    {
        public int Id { get; set; }
        [JsonProperty("all")]
        public int cloudiness { get; set; }
    }
}
