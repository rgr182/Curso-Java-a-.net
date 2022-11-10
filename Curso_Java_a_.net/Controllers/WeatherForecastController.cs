using Microsoft.AspNetCore.Mvc;
using Curso_Java_a_.Classes;

namespace Curso_Java_a_.net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        public readonly ILogger<WeatherForecastController> _logger;
        public readonly IOperaciones _op;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOperaciones op)
        {
            _logger = logger;
            _op = op;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public double Get()
        {
            double s;

            s = _op.Suma(2, 3);
            return _op.Resta(100, s);
        }

        //[HttpPost(Name ="GetWeatherForecast")]
        //public string Post()
        //{
        //    return "El principio del exito siempre empieza por un fracaso"+" Despues que empiezas a entender tus fracasos empiezas a progresar";
        //}
    }
}
