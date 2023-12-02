using advance_csharp.dto.Request;
using advance_csharp.dto.Response;
using Microsoft.AspNetCore.Mvc;

namespace advance_csharp.Controllers
{
    [ApiController]
    [Route("api/Weather")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };

        public WeatherForecastController()
        {
        }

        [Route("GetWeatherForecast")]
        [HttpGet()]
        public IEnumerable<WeatherForecastResponse> Get([FromQuery] int maxIndex)
        {
            return Enumerable.Range(1, 5).Where(a => a < maxIndex).Select(index => new WeatherForecastResponse
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [Route("InsertWeatherForecast")]
        [HttpPost()]
        public IEnumerable<WeatherForecastResponse> Post([FromBody] WeatherForecastRequest request)
        {
            List<WeatherForecastResponse> weathers = new()
            {
                new WeatherForecastResponse
                {
                    Date = DateTime.Now.AddDays(request.DateNum),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }
            };
            return weathers;
        }
    }
}