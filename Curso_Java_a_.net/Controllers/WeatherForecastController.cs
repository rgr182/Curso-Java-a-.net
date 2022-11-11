using Curso_Java_a_.net.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Curso_Java_a_.net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        public IOperacionesMatematicas _operaciones;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IOperacionesMatematicas operaciones)
        {
            _logger = logger;
            _operaciones = operaciones;
        }
        [HttpGet]
        public string Get()
        {
            return "Hola";
        }
        [HttpGet]
        [Route("/GetSuma")]
        public string GetSuma(int a, int b)
        {
            var res = "";
            try
            {
                res = "El resultado de la suma es: " + _operaciones.sumar(a, b);
            }
            catch (ArithmeticException ex)
            {
                res = "Hubo problemas: " + ex.Message;
            }
            catch (Exception ex)
            {
                res = "Hubo problemas: " +ex.Message;
            }
            
            return res;
        }


        [HttpGet]
        [Route("/GetResta")]
        public string GetResta(int a, int b)
        {
            var res = "";
            try
            {
                res = "El resultado de la resta es: " + _operaciones.restar(a, b);
            }
            catch (Exception ex)
            {
                res = "Hubo problemas: " + ex.Message;
            }

            return res;
        }

        [HttpGet]
        [Route("/GetMultiplicacion")]
        public string GetMultiplicacion(int a, int b)
        {
            var res = "";
            try
            {
                res = "El resultado de la multiplicacion es: " + _operaciones.multiplicar(a, b);
            }
            catch (Exception ex)
            {
                res = "Hubo problemas: " + ex.Message;
            }

            return res;
        }

        [HttpGet]
        [Route("/GetDivision")]
        public string GetDivision(int a, int b)
        {
            var res = "";
            try
            {
                res = "El resultado de la divicion es: " + _operaciones.dividir(a, b);
            }
            catch (DivideByZeroException ex)
            {
                res = "Hubo problemas: " + ex.Message;
            }

            return res;
        }
    }
}