using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Domain;

namespace WeatherApp.BusinessLogic.Services
{
    public interface IWeatherService 
    {
        /// <summary>
        /// Get weatherinfo from http://api.openweathermap.org
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<Root> GetWeatherDataAsync(string url);
        
        Task<string> ShowWeatherDataAsync(string CityName);


    }
}
