using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.BusinessLogic.Services
{
    public interface IWeatherService <T> where T : class
    {
        /// <summary>
        /// Get weatherinfo from http://api.openweathermap.org
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<T> GetWeatherDataAsync(string url);
        
        Task<string> ShowWeatherDataAsync(string CityName);


    }
}
