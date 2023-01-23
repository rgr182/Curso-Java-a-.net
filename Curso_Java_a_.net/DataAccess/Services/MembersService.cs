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
        
        public async Task<Member> GetMemberByUserAndPassword(string usuario, string pass)
        {
            try
            {
                Member member = await _membersRepository.GetMemberById(usuario,  pass);
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
        
        public async Task<Member> SaveMembersAsync(Member member)
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

        public async Task<Member> GetMember(int memberId)
        {
            try
            {
                Member member = await _membersRepository.GetMember(memberId);
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
        public async Task<List<Member>> GetMembers()
        {
            try
            {
                List<Member> members = await _membersRepository.GetMember();
                return members;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on Member Service");
                throw ex;
            }
        }

        public async Task<Member> DeleteMembers(int MemberId)
        {
            try
            {
                Member member = _context.Member.Find(MemberId);
                 _context.Member.Remove(member);
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

        public async Task<Member> UpdateMembers(MemberDTO member)
        {
            try
            {
                var memberUpdated = member.Map();
                _context.Member.Update(memberUpdated);
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
