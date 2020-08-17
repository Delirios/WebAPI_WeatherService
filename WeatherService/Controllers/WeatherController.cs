using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherApp.Infrastructure;

namespace WeatherService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        [HttpGet("{cityName}")]
        public async Task<ActionResult<string>> GetWeather(string cityName)
        {
            try
            {
                ShowWeatherData showWeatherData = new ShowWeatherData();
                var result = await showWeatherData.ShowDataAsync(cityName);

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Failed");
            }
        }
    }
}
