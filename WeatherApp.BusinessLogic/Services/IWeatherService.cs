using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Domain;

namespace WeatherApp.BusinessLogic.Services
{
    public interface IWeatherService 
    {
        Task<Root> ShowWeatherDataAsync(string CityName);
        Task<Root> ShowWeatherDataByCoordinatesAsync(double lat, double lon);
    }
}
