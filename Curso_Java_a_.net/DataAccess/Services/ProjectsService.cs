using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class ProjectsService : IProjectsService
    {
        readonly ILogger<ProjectsService> _logger;
        readonly IProjectsRepository _ProjectsRepository;
        internal SchoolSystemContext _context;

        public ProjectsService(IProjectsRepository projectsRepository,
                              ILogger<ProjectsService> logger, SchoolSystemContext context)
        {
            _ProjectsRepository = projectsRepository;
            _logger = logger;
            _context = context;
        }
        public async Task<Projects> GetProject(int projectId)
        {
            try
            {
                Projects getProject = await _ProjectsRepository.GetProject(projectId);
                if (getProject == null)
                {
                    throw new UnauthorizedAccessException();
                }
                return getProject;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on Projects Service");
                throw ex;
            }
        }
        public async Task<List<Projects>> GetProjects()
        {
            try
            {
                return _context.Projects.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on Bootcamps Service");
                throw ex;
            }
        }
        public async Task<Projects> DeleteProject(int projectId)
        {
            try
            {
                Projects project = _context.Projects.Find(projectId);
                _context.Projects.Remove(project);
                _context.SaveChanges();
                return project;

                if (project == null)
                {
                    throw new UnauthorizedAccessException();
                }
                return project;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on bootcamps Service");
                throw ex;
            }
        }

        public async Task<Projects> PostProject(ProjectsDTO name)
        {
            try
            {
                var postProject = name.Map();
                await _context.Projects.AddAsync(postProject);
                await _context.SaveChangesAsync();
                return postProject;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<Projects> UpdateProject(ProjectsDTO name)
        {
            try
            {
                var updatedProject = name.Map();
                await _context.Projects.AddAsync(updatedProject);
                await _context.SaveChangesAsync();
                return updatedProject;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
