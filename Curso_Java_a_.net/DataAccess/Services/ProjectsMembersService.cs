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
    public class ProjectsMembersService : IProjectsMembersService
    {
        readonly ILogger<ProjectsMembersService> _logger;
        readonly IProjectsMembersRepository _projectsMembersRepository;
        public ProjectsMembersService(IProjectsMembersRepository projectsMembersRepository,
                              ILogger<ProjectsMembersService> logger)
        {
            _projectsMembersRepository = projectsMembersRepository;
            _logger = logger;
        }
        public async Task<ProjectsMembers> GetProjectMemberAsync(int projectMemberId)
        {
            try
            {
                ProjectsMembers projectsMember = await _projectsMembersRepository.GetProjectMemberAsync(projectMemberId);
                return projectsMember;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
        public async Task<List<ProjectsMembers>> GetProjectMembersAsync()
        {
            try
            {
                List<ProjectsMembers> projectsMembers= await _projectsMembersRepository.GetProjectMembersAsync();
                return projectsMembers;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
        public async Task<ProjectsMembers> DeleteProjectMemberId(int projectMemberId)
        {
            try
            {
                ProjectsMembers projectsMember = await _projectsMembersRepository.DeleteProjectMemberId(projectMemberId);
                return projectsMember;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
        public async Task<ProjectsMembers> PostProjectMemberAsync(ProjectsMembers projectMemberId)
        {
            try
            {
                ProjectsMembers projectsMember = await _projectsMembersRepository.PostProjectMemberAsync(projectMemberId);
                return projectsMember;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public async Task<ProjectsMembers> UpdateProjectMemberAsync(ProjectsMembers projectMemberId)
        {
            try
            {
                var projectMember = await _projectsMembersRepository.UpdateProjectMemberAsync(projectMemberId);
                return projectMember;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
