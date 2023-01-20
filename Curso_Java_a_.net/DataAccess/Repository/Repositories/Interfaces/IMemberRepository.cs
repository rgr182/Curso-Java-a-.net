using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface IMemberRepository
    {
        public Task<Member> GetMemberById(string user, string pass);
        public Task SaveMemberAsync(Member member);
        public Task<Member> GetMember(int id);
        public Task<List<Member>> GetMember();
        public Task<Member> PostMember(MemberDTO member);
        public Task<Member> UpdateMember(MemberDTO member);
        public Task<Member> DeleteMember(int MemberId);
    }
}
