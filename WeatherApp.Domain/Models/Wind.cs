using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WeatherApp.Domain
{
    public class Wind
    {
        [Key]
        public int WindId { get; set; }
        public double speed { get; set; }
        public int deg { get; set; }
    }
}
