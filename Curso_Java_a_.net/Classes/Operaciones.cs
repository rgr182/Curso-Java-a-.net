namespace Curso_Java_a_.Classes
{
    public interface IOperaciones
    {
        public double Suma(double o1, double o2);
        public double Resta(double o1, double o2);
        public double Mult(double o1, double o2);
        public double Div(double o1, double o2);
    }

    public class OperacionesAritmeticas : IOperaciones
    {
        public double Suma(double o1, double o2) { return o1 + o2; }
        public double Resta(double o1, double o2) { return o1 - o2; }
        public double Mult(double o1, double o2) { return o1 * o2; }
        public double Div(double o1, double o2)
        {
            if (o2 == 0)
                throw new DivideByZeroException();
            return o1 / o2;
        }
    }
}