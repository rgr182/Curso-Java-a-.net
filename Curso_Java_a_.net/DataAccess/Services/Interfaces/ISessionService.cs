using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Services.Interfaces
{
    public interface ISessionService
    {
        public Task<Session> SaveSession(int MemberId);

        public Task<Session> GetSession(int MemberId);     
    }
}
