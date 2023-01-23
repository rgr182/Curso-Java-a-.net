using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface IMemberRepository
    {
        public Task<Members> GetMemberById(string user, string pass);
        public Task SaveMemberAsync(Members member);
        public Task<Members> GetMember(int id);
        public Task<List<Members>> GetMember();
        public Task<Members> PostMember(MemberDTO member);
        public Task<Members> UpdateMember(MemberDTO member);
        public Task<Members> DeleteMember(int MemberId);
    }
}
