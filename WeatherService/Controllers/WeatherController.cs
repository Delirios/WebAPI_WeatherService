using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.BusinessLogic.Services;
using WeatherApp.Domain;

namespace WeatherService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _service;

        public WeatherController(IWeatherService service)
        {
            _service = service;
        }

        [HttpGet("{cityName}")]
        public async Task<Root> GetWeather(string cityName)
        {
            var result = await _service.ShowWeatherDataAsync(cityName);
            return result;
        }

        [HttpGet("{lat}/{lon}")]
        public async Task<Root> GetWeatherByCoordinates(double lat, double lon)
        {
            var result = await _service.ShowWeatherDataByCoordinatesAsync(lat, lon);
            return result;
        }
    }
}
