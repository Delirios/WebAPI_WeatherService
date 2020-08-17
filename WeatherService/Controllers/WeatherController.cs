using Microsoft.AspNetCore.Mvc;

namespace WeatherService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        [HttpGet]
        public IActionResult  GetWeather()
        
        {
            return Ok(new {Moniker = "123123123", Name = "sadasdsa"});
        }
    }
}