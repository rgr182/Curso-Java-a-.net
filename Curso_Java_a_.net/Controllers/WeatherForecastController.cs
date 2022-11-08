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
        public String Get(String nombre)
        {
           
            return "ola papu eres el " + nombre;


            


        }
        
    }
}