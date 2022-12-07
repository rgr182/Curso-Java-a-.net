using Curso_Java_a_.net.Utils.Interfaces;

namespace Curso_Java_a_.net.Utils
{  
    public class Utils : IUtils
    {
        public Guid GenerateToken() => Guid.NewGuid();

        public String GenerateTokenString() => Guid.NewGuid().ToString();
    }
}
