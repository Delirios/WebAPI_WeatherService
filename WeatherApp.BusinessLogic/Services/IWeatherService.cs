using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Domain;

namespace WeatherApp.BusinessLogic.Services
{
    public interface IWeatherService 
    {
        Task<object> ShowWeatherDataAsync(string CityName);
    }
}
