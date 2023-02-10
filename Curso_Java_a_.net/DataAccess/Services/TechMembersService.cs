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
    public class TechMembersService : ITechMembersService
    {
        readonly ILogger<TechMembersService> _logger;
        readonly ITechMembersRepository _ITechMembersRepository;
        internal SchoolSystemContext _context;

        public TechMembersService(ITechMembersRepository techMembersRepository,
                              ILogger<TechMembersService> logger, SchoolSystemContext context)
        {
            _ITechMembersRepository = techMembersRepository;
            _logger = logger;
            _context = context;
        }
        public async Task<TechMembers> GetTechMemberAsync(int techMembersId)
        {
            try
            {
                TechMembers techMember = await _ITechMembersRepository.GetTechMemberAsync(techMembersId);
                return techMember;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on Projects Service");
                throw ex;
            }
        }
        public async Task<List<TechMembers>> GetTechMembersAsync()
        {
            try
            {
                return await _ITechMembersRepository.GetTechMembersAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on Bootcamps Service");
                throw ex;
            }
        }
        public async Task<TechMembers> DeleteTechMemberById(int techMembersId)
        {
            try
            {
                TechMembers techMembers = await _ITechMembersRepository.DeleteTechMemberById(techMembersId);

                if (techMembers == null)
                {
                    throw new UnauthorizedAccessException();
                }
                return techMembers;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on bootcamps Service");
                throw ex;
            }
        }

        public async Task<TechMembers> PostTechMemberAsync(TechMembers techMembersId)
        {
            try
            {
                TechMembers techMembers = await _ITechMembersRepository.PostTechMemberAsync(techMembersId);
                return techMembers;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<TechMembers> UpdateTechMemberAsync(TechMembers techMembersId)
        {
            try
            {
                return await _ITechMembersRepository.UpdateTechMemberAsync(techMembersId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
