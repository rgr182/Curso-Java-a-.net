using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

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

        public async Task<Projects> PostProject(ProjectsDTO name)
        {
            var postProject = name.Map();
            await _context.Projects.AddAsync(postProject);
            await _context.SaveChangesAsync();
            return postProject;
        }

        public async Task<Projects> UpdateProject(ProjectsDTO name)
        { 
            var updatedProject = name.Map();
            await _context.Projects.AddAsync(updatedProject);
            await _context.SaveChangesAsync();
            return updatedProject;
        }

        public async Task<Projects> DeleteProject(int projectId)
        {
            Projects deleteProject = await _context.Projects.FindAsync(projectId);
            _context.Projects.Remove(deleteProject);
            _context.SaveChanges();
            return deleteProject;
        }
    }
}
