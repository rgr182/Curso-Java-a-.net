using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class MembersService : IMembersService
    {
        readonly ILogger<UsersService> logger;
        IMembersRepository _membersRepository;
        public MembersService(IMembersRepository membersRepository, ILogger<UsersService> logger)
        {
            _membersRepository = membersRepository;
            this.logger = logger;
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
                logger.LogError(ex, "Error in MemberService");
                throw ex;
            }
        }     
    }
}
