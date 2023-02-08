using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface IProjectsRepository
    {
        public Task<Projects> GetProject(int projectId);
        public Task<List<Projects>> GetProjects();
        public Task<Projects> PostProject(ProjectsDTO name);
        public Task<Projects> UpdateProject(ProjectsDTO name);
        public Task<Projects> DeleteProject(int projectId);
    }
}
