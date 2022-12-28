using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Repositories;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using Microsoft.Identity.Client;
using System.Diagnostics.Metrics;
using static Dapper.SqlMapper;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class MembersService : IMembersService
    {
        readonly ILogger<MembersService> _logger;
        IMembersRepository _membersRepository;
        public MembersService(IMembersRepository membersRepository,
                              ILogger<MembersService> logger)
        {
            _membersRepository = membersRepository;
            _logger = logger;
        }      
        
        public async Task<Members> GetMemberByUserAndPassword(string usuario, string pass)
        {
            try
            {
                Members member = await _membersRepository.GetMemberById(usuario,  pass);
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
                _logger.LogError(ex, "Some error happened on Members Service");
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
                _logger.LogError(ex, "Some error happened on Members Service");
                throw ex;
            }
        }

        public async Task<Members> DeleteMembers(int id)
        {
            try
            {
                Members member = await _membersRepository.DeleteMembers(id);
                if (member == null)
                {
                    throw new UnauthorizedAccessException();
                }
                return member;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on Members Service");
                throw ex;
            }
        }




       




















        public async Task<Members> PostMembers(Members members)
        {
            try
            {
                await _membersRepository.PostMembers(members);
                return members;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<Members> UpdateMembers(Members members)
        {
            try
            {
                await _membersRepository.UpdateMembers(members);
                return members;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }


       /* public async Task<Members> DeleteMembers(long memberId)
        {
            try
            {
                await _membersRepository.DeleteMembers(memberId);

            }
            catch (Exception)
            {

                throw;
            }

        }*/




    }
}
