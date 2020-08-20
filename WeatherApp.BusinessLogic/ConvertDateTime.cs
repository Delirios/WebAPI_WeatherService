using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.BusinessLogic
{
    public class ConvertDateTime
    {
        public DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
    }
}
