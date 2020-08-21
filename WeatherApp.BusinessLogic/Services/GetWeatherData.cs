using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Domain;

namespace WeatherApp.BusinessLogic
{
    public class GetWeatherData
    {
        public async Task<Root> GetWeatherDataAsync(string url)
        {

            WebRequest webRequest = WebRequest.Create(url);
            WebResponse webResponse = await webRequest.GetResponseAsync();
            using (Stream stream = webResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream);

                string responceFromServer = await reader.ReadToEndAsync();
                Root result = JsonConvert.DeserializeObject<Root>(responceFromServer);
                return result;
            }
        }
    }
}
