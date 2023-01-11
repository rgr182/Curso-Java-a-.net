using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Services.Interfaces
{
    public interface IMembersService
    {
        public Task<Members> GetMemberByUserAndPassword(string user, string pass);
        public Task<Members> SaveMembersAsync(Members member);
        public Task<Members> GetMember(int memberId);
        public Task<MemberDTO> PostMembers(MemberDTO member);
        public Task<Members> UpdateMembers(MemberDTO member);
        public Task<Members> DeleteMembers(int MembersId);
    }
}
