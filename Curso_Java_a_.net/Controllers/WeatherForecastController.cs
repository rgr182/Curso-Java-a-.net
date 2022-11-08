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
        private string saludar(string name)
        {
            return "Hola " + name;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public string Get(string name)
        {
            string saludo = saludar(name);
            return saludo;
        }
    }
}