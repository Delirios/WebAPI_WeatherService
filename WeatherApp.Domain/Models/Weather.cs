﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace WeatherApp.Domain
{
    public class Weather
    {
        [Key]
        public int WeatherId { get; set; }
        [JsonProperty("id")]
        public int condition { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        public DateTime request_date { get; set; }
    }
}
