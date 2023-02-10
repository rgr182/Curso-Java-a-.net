using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Services.Interfaces
{
    public interface IProjectsService
    {
        public Task<Projects> GetProject(int projectId);
        public Task<List<Projects>> GetProjects();
        public Task<ProjectsDTO> PostProject(ProjectsDTO name);
        public Task<ProjectsDTO> UpdateProject(ProjectsDTO name);
        public Task<Projects> DeleteProject(int projectId);
    }
}
