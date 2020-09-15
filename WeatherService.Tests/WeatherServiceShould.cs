using System;
using System.Diagnostics;
using WeatherApp.BusinessLogic;
using Xunit;

namespace WeatherService.Tests
{
    public class WeatherServiceShould
    {
        [Fact] 
        public async void ReturnNotNull()
        {
            WeatherApp.BusinessLogic.Services.WeatherService sut  = new WeatherApp.BusinessLogic.Services.WeatherService();
            const string api_key = "d59f2794ce9666f810bad9ece5322791";
            const string units = "metric";
            const string lang = "ua";
            const string CityName = "Lviv";

            string url = "http://api.openweathermap.org/data/2.5/weather?q="
                         + CityName + "&appid=" + api_key + "&units=" + units + "&lang=" + lang;


            object json = await sut.GetJsonDataAsync(url);
            

            Assert.NotNull(json);
        }
    }
}
