using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherApp.BusinessLogic;
using WeatherApp.BusinessLogic.Services;

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


        [HttpGet("{cityName}")]
        public async Task<ActionResult<string>> GetWeather(string cityName)
        {
            
            try
            {
                var result = await _service.ShowWeatherDataAsync(cityName);
                //var result = await showWeatherData.ShowDataAsync(cityName);

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Failed");
            }
        }
    }
}
