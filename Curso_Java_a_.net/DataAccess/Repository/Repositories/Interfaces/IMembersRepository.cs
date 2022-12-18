using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface IMembersRepository
    {
        public Task<Members> GetMemberById(string user, string pass);
        public Task SaveMemberAsync(Members member);
        public Task<Members> GetMember(long id);
    }
}
