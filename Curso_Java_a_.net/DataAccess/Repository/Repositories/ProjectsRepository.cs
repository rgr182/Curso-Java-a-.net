using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class ProjectsRepository : IProjectsRepository
    {
        internal SchoolSystemContext _context;
        public ProjectsRepository(SchoolSystemContext context)
        {
            _context = context;
        }
        public async Task<List<Projects>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Projects> GetProject(int projectId) =>
          
            await _context.Projects
           .Where(x => x.ProjectId == projectId)
              .FirstOrDefaultAsync();

        public async Task<Projects> PostProject(ProjectsDTO project)
        {
            var postProject = project.Map();
            await _context.Projects.AddAsync(postProject);
            await _context.SaveChangesAsync();
            return postProject;
        }

        public async Task<Projects> UpdateProject(ProjectsDTO project)
        { 
            var updatedProject = project.Map();
            _context.Projects.Update(updatedProject);
            await _context.SaveChangesAsync();
            return updatedProject;
        }

        public async Task<Projects> DeleteProject(int projectId)
        {
            Projects deleteProject = await _context.Projects.FindAsync(projectId);
            if (deleteProject == null)
            {
                return null;
            }
            _context.Projects.Remove(deleteProject);
            await _context.SaveChangesAsync();
            return deleteProject;
        }
    }
}
