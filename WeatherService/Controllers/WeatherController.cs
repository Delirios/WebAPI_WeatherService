using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherApp.BusinessLogic;
using WeatherApp.BusinessLogic.Services;
using WeatherApp.Domain;

namespace WeatherService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private IWeatherService _service;

        public WeatherController(IWeatherService service)
        {
            _service = service;
        }

        //[HttpGet("{cityName}")]
        //public async Task<ActionResult<string>> GetWeather(string cityName)
        //{
        //    try
        //    {
        //        var result = await _service.ShowWeatherDataAsync(cityName);
        //        return result;
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Server Failed");
        //    }
        //}
        [HttpGet("{cityName}")]
        public async Task<ActionResult<Object>> GetWeather(string cityName)
        {
            try
            {
                var result = await _service.ShowWeatherDataAsync(cityName);

                return result;
            }
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Failed");
            }
        }
        [HttpGet("{lat}/{lon}")]
        public async Task<ActionResult<Object>> GetWeatherByCoordinates(double lat, double lon)
        {
            try
            {
                var result = await _service.ShowWeatherDataByCoordinatesAsync(lat, lon);

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Failed");
            }
        }

    }
}
