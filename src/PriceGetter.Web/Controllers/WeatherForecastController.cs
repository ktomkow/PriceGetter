using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PriceGetter.Web.Controllers
{
    public class WeatherForecastController : AbstractController
    {
        public string[] Summaries => this.weatherProvider.Get();

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherProvider weatherProvider;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherProvider weatherProvider)
        {
            _logger = logger;
            this.weatherProvider = weatherProvider;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
