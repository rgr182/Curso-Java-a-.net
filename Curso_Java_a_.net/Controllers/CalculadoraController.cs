using Curso_Java_a_.net.Context.DAL;
using Curso_Java_a_.net.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Curso_Java_a_.net.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraController : ControllerBase
    {

        private readonly ILogger<CalculadoraController> _Logger;
        public IOperacionesMatematicas _Operaciones;
        private EscuelaContext _EscuelaContext;

        public CalculadoraController(ILogger<CalculadoraController> Logger,
            IOperacionesMatematicas Operaciones)
        {
            _Logger = Logger;
            _Operaciones = Operaciones;
        }

        [HttpGet]
        [Route("/GetSuma")]
        public string GetSuma(int a, int b)
        {
            var res = "";
            try
            {
                res = "El resultado de la suma es: " + _Operaciones.sumar(a, b);
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
                res = "El resultado de la resta es: " + _Operaciones.restar(a, b);
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
                res = "El resultado de la multiplicacion es: " + _Operaciones.multiplicar(a, b);
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
                res = "El resultado de la divicion es: " + _Operaciones.dividir(a, b);
            }
            catch (DivideByZeroException ex)
            {
                res = "Hubo problemas: " + ex.Message;
            }

            return res;
        }
    }
}