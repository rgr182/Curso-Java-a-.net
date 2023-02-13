using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class TechMembersService : ITechMembersService
    {
        readonly ILogger<TechMembersService> _logger;
        readonly ITechMembersRepository _techMembersRepository;
        internal SchoolSystemContext _context;

        public TechMembersService(ITechMembersRepository techMembersRepository,
                              ILogger<TechMembersService> logger, SchoolSystemContext context)
        {
            _techMembersRepository = techMembersRepository;
            _logger = logger;
            _context = context;
        }
        public async Task<TechMembers> GetTechMemberAsync(int techMembersId)
        {
            try
            {
                TechMembers techMember = await _techMembersRepository.GetTechMemberAsync(techMembersId);
                return techMember;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
        public async Task<List<TechMembers>> GetTechMembersAsync()
        {
            try
            {
                List<TechMembers> techMembers = await _techMembersRepository.GetTechMembersAsync();
                return techMembers;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
        public async Task<TechMembers> DeleteTechMemberById(int techMembersId)
        {
            try
            {
                TechMembers techMembers = await _techMembersRepository.DeleteTechMemberById(techMembersId);
                return techMembers;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public async Task<TechMembers> PostTechMemberAsync(TechMembers techMembersId)
        {
            try
            {
                TechMembers techMembers = await _techMembersRepository.PostTechMemberAsync(techMembersId);
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
                return await _techMembersRepository.UpdateTechMemberAsync(techMembersId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public async Task<List<TechMembersDTO>> GetTechsMemberAsync(int memberId)
        {
            try
            {
                var
                 techMembers = await _techMembersRepository.GetTechsMemberAsync(memberId);
                return techMembers;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
    }
}
