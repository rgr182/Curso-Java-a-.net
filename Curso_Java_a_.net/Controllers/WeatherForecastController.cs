using Microsoft.AspNetCore.Mvc;

namespace Curso_Java_a_.net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        public readonly ILogger<WeatherForecastController> _logger;


        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public double Get()
        {
            var var1 = 2.56;
            double var2 = 6.72;
            var res = var1 + var2;

            return res;
        }
    }
}