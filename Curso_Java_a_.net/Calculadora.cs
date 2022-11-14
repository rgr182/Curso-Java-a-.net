//using Curso_Java_a_.net.Interfaces;

namespace Curso_Java_a_.net.Classes {
    public class Calculadora:ICalculadora
    {
        public Calculadora()
        {
        }

        public double Operacion(double Valor1, char Simbolo, double Valor2) { 
            
            return Valor1 + Valor2;
        }

    }

}



