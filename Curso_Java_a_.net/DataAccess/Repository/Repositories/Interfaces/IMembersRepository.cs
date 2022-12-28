using Curso_Java_a_.net.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface IMembersRepository
    {
        public Task<Members> GetMemberById(string user, string pass);
        public Task SaveMemberAsync(Members member);
      public Task<Members> GetMember(int id);

        public Task <Members> PostMembers(Members member);

        public Task<Members> UpdateMembers(Members member);

       public Task<Members> DeleteMembers(int MembersId);


    }
}
