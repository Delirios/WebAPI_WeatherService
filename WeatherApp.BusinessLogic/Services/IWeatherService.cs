using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.BusinessLogic.Services
{
    public interface IWeatherService
    {
        /// <summary>
        /// Get weatherinfo from http://api.openweathermap.org
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        Task GetWeatherDataAsync(string url);

        Task ShowWeatherDataAsync(string CityName);


    }
}
