using Microsoft.AspNetCore.Mvc;
using Curso_Java_a_.net.Classes;
using Curso_Java_a_.net.Data.Access.Services;

namespace Curso_Java_a_.net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        public readonly ILogger<WeatherForecastController> _logger;
        //public readonly IOperaciones _op;
        public readonly IOperaciones _query;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOperaciones query)
        {
            _logger = logger;
            _query = query;
        }

        [HttpGet(Name = "GetGreater")]
        public int Get()
        {
            return _query.showUsuarios();
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