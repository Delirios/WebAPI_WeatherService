using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Domain
{
    public class Sys
    {
        public int id { get; set; }
        public int type { get; set; }
        public double message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }
}
