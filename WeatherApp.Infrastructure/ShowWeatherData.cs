using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Domain;

namespace WeatherApp.Infrastructure
{
    public class ShowWeatherData
    {
        public async Task<string> ShowDataAsync(string CityName)
        {
            string api_key = "d59f2794ce9666f810bad9ece5322791";
            string units = "metric";
            string lang = "ua";
            string url = "http://api.openweathermap.org/data/2.5/weather?q="
                         + CityName + "&appid=" + api_key + "&units=" + units + "&lang=" + lang;

            GetWeatherData getWeather = new GetWeatherData();
            Root root = new Root();
            {
                root = await getWeather.GetWeatherDataAsync(url);
                var listWeather = root.weather.Select(p => p.description);
                string weatherDescription = "";
                foreach (var item in listWeather)
                {
                    weatherDescription += item;
                }

                ConvertDateTime convertDateTime = new ConvertDateTime();
                var sunriseTime = convertDateTime.ConvertFromUnixTimestamp(root.sys.sunrise).ToLocalTime();
                var sunsetTime = convertDateTime.ConvertFromUnixTimestamp(root.sys.sunset).ToLocalTime();
            }

            string json = JsonConvert.SerializeObject(root, Formatting.Indented);
            return json;
        }
    }
}
