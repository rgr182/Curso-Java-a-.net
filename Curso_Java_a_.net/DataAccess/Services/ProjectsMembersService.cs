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
        readonly IProjectsMembersRepository _IProjectsMembersRepository;
        public ProjectsMembersService(IProjectsMembersRepository projectsMembersRepository,
                              ILogger<ProjectsMembersService> logger)
        {
            _IProjectsMembersRepository = projectsMembersRepository;
            _logger = logger;
        }
        public async Task<ProjectsMembers> GetProjectMemberAsync(int projectMemberId)
        {
            try
            {
                ProjectsMembers projectsMember = await _IProjectsMembersRepository.GetProjectMemberAsync(projectMemberId);
                return projectsMember;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on Projects Service");
                throw ex;
            }
        }
        public async Task<List<ProjectsMembers>> GetProjectMembersAsync()
        {
            try
            {
                return await _IProjectsMembersRepository.GetProjectMembersAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on Bootcamps Service");
                throw ex;
            }
        }
        public async Task<ProjectsMembers> DeleteProjectMemberId(int projectMemberId)
        {
            try
            {
                ProjectsMembers projectsMember = await _IProjectsMembersRepository.DeleteProjectMemberId(projectMemberId);

                if (projectsMember == null)
                {
                    throw new UnauthorizedAccessException();
                }
                return projectsMember;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on bootcamps Service");
                throw ex;
            }
        }
        public async Task<ProjectsMembers> PostProjectMemberAsync(ProjectsMembers projectMemberId)
        {
            try
            {
                ProjectsMembers projectsMember = await _IProjectsMembersRepository.PostProjectMemberAsync(projectMemberId);
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
                return await _IProjectsMembersRepository.UpdateProjectMemberAsync(projectMemberId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
