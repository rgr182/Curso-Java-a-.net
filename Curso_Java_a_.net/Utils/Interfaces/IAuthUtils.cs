using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.Utils.Interfaces
{
    public interface IAuthUtils
    {
        string GenerateJWT(Members member);
    }
}
