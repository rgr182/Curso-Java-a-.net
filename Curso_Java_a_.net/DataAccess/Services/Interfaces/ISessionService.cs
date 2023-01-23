using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Services.Interfaces
{
    public interface ISessionService
    {
        public Task<Sessions> SaveSession(Members member);

        public Task<Sessions> GetSession(int MemberId);     
    }
}
