using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class ProjectsMembersRepository : IProjectsMembersRepository
    {
        internal SchoolSystemContext _context;
        public ProjectsMembersRepository(SchoolSystemContext context)
        {
            _context = context;
        }
        public async Task<List<ProjectsMembers>> GetProjectMembersAsync()
        {
            return await _context.ProjectsMembers.ToListAsync();
        }

        public async Task<ProjectsMembers> GetProjectMemberAsync(int projectMemberId) =>
          
            await _context.ProjectsMembers
           .Where(x => x.ProjectMemberId == projectMemberId)
              .FirstOrDefaultAsync();

        public async Task<ProjectsMembers> PostProjectMemberAsync(ProjectsMembers projectMemberId)
        {
            await _context.ProjectsMembers.AddAsync(projectMemberId);
            _context.SaveChanges();
            return projectMemberId;
        }

        public async Task<ProjectsMembers> UpdateProjectMemberAsync(ProjectsMembers projectMemberId)
        {
            ProjectsMembers projectMembers = _context.ProjectsMembers.Find(projectMemberId);
            _context.ProjectsMembers.Update(projectMembers);
            _context.SaveChanges();
            return projectMembers;
        }

        public async Task<ProjectsMembers> DeleteProjectMemberId(int projectMemberId)
        {
            ProjectsMembers projectMembers = await _context.ProjectsMembers.FindAsync(projectMemberId);
            _context.ProjectsMembers.Remove(projectMembers);
            _context.SaveChanges();
            return projectMembers;
        }
    }
}