using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WeatherApp.Domain
{
    public class Coordinates
    {
        [Key]
        public int CoordinateId { get; set; }
        public double lon { get; set; }
        public double lat { get; set; }
    }
}
