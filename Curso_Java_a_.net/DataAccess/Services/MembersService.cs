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
        internal SchoolSystemContext _context;
        
        public MembersService(IMemberRepository membersRepository,
                              ILogger<MembersService> logger, SchoolSystemContext context)
        {
            _membersRepository = membersRepository;
            _logger = logger;
            _context = context;
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
                _logger.LogError(ex, "Error in MemberService");
                throw ex;
            }
        }
        
        public async Task<Members> SaveMembersAsync(Members member)
        {
            try
            {
               await _membersRepository.SaveMemberAsync(member);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on Member Service");
                throw ex;
            }

            return member;
        }

        public async Task<Members> GetMember(int memberId)
        {
            try
            {
                Members member = await _membersRepository.GetMember(memberId);
                if (member == null)
                {
                    throw new UnauthorizedAccessException();
                }
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
                List<Members> members = await _membersRepository.GetMember();
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
                Members member = _context.Members.Find(MemberId);
                 _context.Members.Remove(member);
                 _context.SaveChanges();
                return member;
                
                if (member == null)
                {
                    throw new UnauthorizedAccessException();
                }
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
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<Members> UpdateMembers(MemberDTO member)
        {
            try
            {
                var memberUpdated = member.Map();
                _context.Members.Update(memberUpdated);
                await _context.SaveChangesAsync();
                return memberUpdated;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
