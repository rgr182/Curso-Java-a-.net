using Microsoft.AspNetCore.Mvc;
using Curso_Java_a_.Classes;

namespace Curso_Java_a_.net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        public readonly ILogger<WeatherForecastController> _logger;
        //public readonly IOperaciones _op;
        public readonly IConsulta _query;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConsulta query)
        {
            _logger = logger;
            _query = query;
        }

<<<<<<< HEAD
        [HttpGet(Name = "GetWeatherForecast")]
        public double Get()
        {
            var var1 = 2.56;
            double var2 = 6.72;
            var res = var1 + var2;

            return res;
=======
        [HttpGet(Name = "GetGreater")]
        public int Get()
        {
            return _query.showUsuarios();
>>>>>>> origin/Dorian
        }

        //[HttpGet(Name = "GetGreater")]
        //public double GetCalc(double a, char sign, double b)
        //{
        //    switch(sign)
        //    {
        //        case '+': return _op.Suma(a, b);
        //        case '-': return _op.Resta(a, b);
        //        case '*': return _op.Mult(a, b);
        //        case '/': return _op.Div(a, b);
        //        default: throw new ArgumentException();
        //    }
        //    return 0;
        //}
    }
}
