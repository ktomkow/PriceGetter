using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceGetter.Web
{
    public class WeatherProvider : IWeatherProvider
    {
        public string[] Get()
        {
        return new[]
                {
                    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
                };
        }
    }
}
