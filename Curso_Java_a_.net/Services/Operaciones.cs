using Curso_Java_a_.net.Controllers;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace Curso_Java_a_.net.Services
{
    public class Operaciones : IOperaciones
    {
        ILogger<WeatherForecastController> _logger;

        public Operaciones(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        public int Suma(int a, int b)
        {
            int resultado = 0;
            try
            {
                resultado = a + b;
            }
            catch (Exception exp)
            {
                _logger.LogError("algo trono compadre", exp);
            }

            return resultado;
        }

        public int Resta(int a, int b)
        {
            return a - b;
        }

        public double Division(int a, int b)
        {
            return a / b;
        }
    }
}
