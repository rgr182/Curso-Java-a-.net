using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface IMembersRepository
    {
        public Task<Members> GetMemberById(string user, string pass);
        //public void PostMember(Members user);
        //public void PutMember(Members user);
        //public void DeleteMember(int id);
    }
}
