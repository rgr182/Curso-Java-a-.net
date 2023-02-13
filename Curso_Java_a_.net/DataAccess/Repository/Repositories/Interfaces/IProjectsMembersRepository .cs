using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface IProjectsMembersRepository
    {
        public Task<ProjectsMembers> GetProjectMemberAsync(int projectMemberId);
        public Task<List<ProjectsMembers>> GetProjectMembersAsync();
        public Task<ProjectsMembers> PostProjectMemberAsync(ProjectsMembers projectMemberId);
        public Task<ProjectsMembers> UpdateProjectMemberAsync(ProjectsMembers projectMemberId);
        public Task<ProjectsMembers> DeleteProjectMemberId(int projectMemberId);
        public Task<List<ProjectsMembersDTO>> GetProjectsMembersAsync();
    }
}
