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
        public int Get()
        {
            return 123;
        }

        //[HttpPost(Name ="GetWeatherForecast")]
        //public string Post()
        //{
        //    return "El principio del exito siempre empieza por un fracaso"+" Despues que empiezas a entender tus fracasos empiezas a progresar";
        //}
    }
}
