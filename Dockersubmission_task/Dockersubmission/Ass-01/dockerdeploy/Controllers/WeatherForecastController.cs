using Microsoft.AspNetCore.Mvc;

namespace dockerdeploy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezingviki", "Bracingviki", "Chillyviki", "Coolviki", "Mildviki", "Warmviki", "Balmyviki", "Hotviki", "Swelteringviki", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            Console.WriteLine("wheather controller hit");
            var connectionString = Environment.GetEnvironmentVariable("connectionstring");
            Console.WriteLine("env values"+ connectionString);
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}