using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.DataAccessLayer;
using WeatherApp.Domain;

namespace WeatherApp.BusinessLogic.Services
{

    public class WeatherService : IWeatherService
    {
        const string api_key = "d59f2794ce9666f810bad9ece5322791";
        const string units = "metric";
        const string lang = "ua";

        private readonly WeatherContext _context;

        public WeatherService(WeatherContext context)
        {
            _context = context;
        }

        public WeatherService()
        {
        }
        public async Task<Root> GetWeatherDataAsync(string url)
        {
            WebRequest webRequest = WebRequest.Create(url);
                WebResponse webResponse = await webRequest.GetResponseAsync();
                using (Stream stream = webResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    string responceFromServer = await reader.ReadToEndAsync();
                    Root result = JsonConvert.DeserializeObject<Root>(responceFromServer);
                    try
                    {
                        using (_context)
                        {
                            _context.Roots.Add(result);
                            _context.SaveChanges();
                        }
                    }
                    catch (Exception exception)
                    {
                        Debug.WriteLine(new string('-',50));
                        Debug.WriteLine(exception);
                    }
                    return result;
                }
        }
        public async Task<Root> ShowWeatherDataAsync(string CityName)
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q="
                         + CityName + "&appid=" + api_key + "&units=" + units + "&lang=" + lang;
            var result = await GetJsonDataAsync(url);
            return result;
        }

        public async Task<Root> ShowWeatherDataByCoordinatesAsync(double lat, double lon)
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?lat=" 
                         + lat + "&lon="+ lon+ "&appid=" + api_key + "&units=" + units + "&lang=" + lang;

            var result = await GetJsonDataAsync(url);
            return result;
        }

        public async Task<Root> GetJsonDataAsync(string url)
        {
            Root root = new Root();
            {
                root = await GetWeatherDataAsync(url);
                var listWeather = root.weather.Select(p => p.description);
                string weatherDescription = "";
                foreach (var item in listWeather)
                {
                    weatherDescription += item;
                }
            }
            return root;
        }
    }
}
