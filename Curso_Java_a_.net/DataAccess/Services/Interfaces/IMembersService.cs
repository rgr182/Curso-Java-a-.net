using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Services.Interfaces
{
    public interface IMembersService
    {
        public Task<Member> GetMemberByUserAndPassword(string user, string pass);
        public Task<Member> SaveMembersAsync(Member member);
        public Task<Member> GetMember(int memberId);
        public Task<List<Member>> GetMembers();
        public Task<MemberDTO> PostMembers(MemberDTO member);
        public Task<Member> UpdateMembers(MemberDTO member);
        public Task<Member> DeleteMembers(int MembersId);
    }
}
