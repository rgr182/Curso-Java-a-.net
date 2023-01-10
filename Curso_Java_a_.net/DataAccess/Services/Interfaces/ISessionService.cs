using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Services.Interfaces
{
    public interface ISessionService
    {
        public Task<Session> SaveSession(Users user);

        public Task<Session> GetSession(long UserId);     
    }
}
