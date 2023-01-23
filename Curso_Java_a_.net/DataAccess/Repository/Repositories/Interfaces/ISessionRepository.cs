using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface ISessionRepository
    {
        public Task<Sessions> GetSession(int UserId);
        public Task AddSession(Sessions session);
    }
}
