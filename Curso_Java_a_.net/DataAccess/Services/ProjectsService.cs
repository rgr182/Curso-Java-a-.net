using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class ProjectsService : IProjectsService
    {
        readonly ILogger<ProjectsService> _logger;
        readonly IProjectsRepository _ProjectsRepository;
        public ProjectsService(IProjectsRepository projectsRepository,
                              ILogger<ProjectsService> logger)
        {
            _ProjectsRepository = projectsRepository;
            _logger = logger;
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
                List<Projects> project = await _ProjectsRepository.GetProjects();
                return project;
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
                Projects project = await _ProjectsRepository.DeleteProject(projectId);
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
        public async Task<ProjectsDTO> PostProject(ProjectsDTO name)
        {
            try
            {
                await _ProjectsRepository.PostProject(name);    
                return name;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public async Task<ProjectsDTO> UpdateProject(ProjectsDTO name)
        {
            try
            {
                await _ProjectsRepository.UpdateProject(name);
                return name;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
