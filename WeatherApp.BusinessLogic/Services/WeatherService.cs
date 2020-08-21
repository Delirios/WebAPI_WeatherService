using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Domain;

namespace WeatherApp.BusinessLogic.Services
{
    class WeatherService : IWeatherService<Root>
    {
        public async Task<Root> GetWeatherDataAsync(string url)
        {
            

                WebRequest webRequest = WebRequest.Create(url);
                WebResponse webResponse = await webRequest.GetResponseAsync();
                using (Stream stream = webResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);

                    string responceFromServer = await reader.ReadToEndAsync();
                    Root result = JsonConvert.DeserializeObject<Root>(responceFromServer);
                    return result;
                }

        }

        public async Task<string> ShowWeatherDataAsync(string CityName)
        {
            string api_key = "";  // your api_key from the http://api.openweathermap.org
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
