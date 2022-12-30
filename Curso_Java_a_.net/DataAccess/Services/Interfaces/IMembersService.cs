using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Services.Interfaces
{
    public interface IMembersService
    {
        public Task<Members> GetMemberByUserAndPassword(string user, string pass);
        
        public Task<Members> SaveMembersAsync(Members member);
        public Task<Members> GetMember(int memberId);

        public Task<Members> PostMembers(Members member);

        public Task<Members> UpdateMembers(Members members);

       public Task<Members> DeleteMembers(int MembersId);
    }
}
