using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface ITechMembersRepository
    {
        public Task<TechMembers> GetTechMemberAsync(int techMembersId);
        public Task<List<TechMembers>> GetTechMembersAsync();
        public Task<TechMembers> PostTechMemberAsync(TechMembers techMembersId);
        public Task<TechMembers> UpdateTechMemberAsync(TechMembers techMembersId);
        public Task<TechMembers> DeleteTechMemberById(int techMembersId);
    }
}
