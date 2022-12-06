using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Services.Interfaces
{
    public interface IMembersService
    {
        public Task<Members> GetMemberByUserAndPassword(string user, string pass);  
    }
}
