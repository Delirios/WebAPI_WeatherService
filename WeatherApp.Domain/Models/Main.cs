﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Domain
{
    public class Main
    {
        public int Id { get; set; }
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }
}
