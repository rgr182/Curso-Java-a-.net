using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Services.Interfaces
{
    public interface ISessionService
    {
        public Task SaveSession(int UserID);

        public Task<Session> GetSession(int UserId);     
    }
}
