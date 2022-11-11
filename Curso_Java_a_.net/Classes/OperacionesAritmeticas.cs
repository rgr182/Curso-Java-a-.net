using Curso_Java_a_.net.DataAccess;
namespace Curso_Java_a_.net.Classes
{
    public class OperacionesMatematicas : IOperacionesMatematicas
    {
        public int sumar(int a, int b)
        {
            return a + b;
        }
        public int restar(int a, int b)
        {
            return a - b;
        }
        public int dividir(int a, int b)
        {
            return a / b;
        }
        public int multiplicar(int a, int b)
        {
            return a * b;
        }
    }
}
