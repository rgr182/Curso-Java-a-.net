using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class MembersService : IMembersService
    {
        readonly ILogger<MembersService> _logger;
        readonly IMemberRepository _membersRepository;
        public MembersService(IMemberRepository membersRepository,
                              ILogger<MembersService> logger)
        {
            _membersRepository = membersRepository;
            _logger = logger;
        }      
        
        public async Task<Members> GetMemberByUserAndPassword(string usuario, string pass)
        {
            try
            {
                Members member = await _membersRepository.GetMemberByUserAndPassword(usuario,  pass);
                if (member == null)
                {
                    throw new UnauthorizedAccessException();
                }

                return member;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Member Service");
                throw ex;
            }
        }
        public async Task<Members> GetMember(int memberId)
        {
            try
            {
                Members member = await _membersRepository.GetMember(memberId);
                return member;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on Member Service");
                throw ex;
            }
        }
        public async Task<List<Members>> GetMembers()
        {
            try
            {
                List<Members> members = await _membersRepository.GetMembers();
                return members;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on Member Service");
                throw ex;
            }
        }

        public async Task<Members> DeleteMembers(int MemberId)
        {
            try
            {
                Members member = await _membersRepository.DeleteMember(MemberId);
                return member;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on Member Service");
                throw ex;
            }
        }

        public async Task<MemberDTO> PostMembers(MemberDTO member)
        {
            try
            {
                await _membersRepository.PostMember(member);
                return member;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on Member Service");
                throw;
            }
        }

        public async Task<Members> UpdateMembers(MemberDTO member)
        {
            try
            {
                var memberUpdated = await _membersRepository.UpdateMember(member);
                return memberUpdated;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException, "Some error happened on Member Service");
                throw;
            }
        }
    }
}
