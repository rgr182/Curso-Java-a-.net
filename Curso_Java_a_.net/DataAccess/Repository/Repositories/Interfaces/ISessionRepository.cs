using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Services;


namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{

    public interface ISessionRepository
    {
        public Task<Session> GetSession(int UserId);

        public Task AddSession(Session session);      

    }
}
