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
            var num1 = 12;
            var num2 = 19;
            int res = num1 + num2;
            return saludo + " " + res;
        }

        //[HttpPost(Name ="GetWeatherForecast")]
        //public string Post()
        //{
        //    return "El principio del exito siempre empieza por un fracaso"+" Despues que empiezas a entender tus fracasos empiezas a progresar";
        //}
    }
}