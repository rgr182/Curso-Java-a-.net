using Curso_Java_a_.net.Controllers;
using Curso_Java_a_.net.DataAccess;
namespace Curso_Java_a_.net.Classes
{
    public class OperacionesMatematicas : IOperacionesMatematicas
    {

        ILogger<WeatherForecastController> _logger;
        public OperacionesMatematicas(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        public int sumar(int a, int b)
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
        public int restar(int a, int b)
        {
            return a - b;
        }
        public double dividir(int a, int b)
        {
            return a / b;
        }

        int IOperacionesMatematicas.dividir(int a, int b)
        {
            throw new NotImplementedException();
        }
    }
}
