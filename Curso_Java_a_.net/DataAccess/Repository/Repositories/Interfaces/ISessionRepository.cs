using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface ISessionRepository
    {
        public Task<Session> GetSession(long UserId);
        public Task AddSession(Session session);
    }
}
