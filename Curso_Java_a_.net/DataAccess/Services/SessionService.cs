using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class SessionService : ISessionService
    {
        readonly ILogger<MembersService> _logger;
        readonly ISessionRepository _securityRepository;

        public SessionService(ILogger<MembersService> logger, ISessionRepository securityRepository)
        {
            _logger = logger;
            _securityRepository = securityRepository;
        }

        public async Task<Session> GetSession(int UserId)
        {
           return await _securityRepository.GetSession(UserId);
        }

        public async Task SaveSession(int UserID)
        {
            try
            {
                await _securityRepository
                   .AddSession(new Session()
                   {
                       CreationDate = DateTime.UtcNow,
                       ExpirationDate = DateTime.UtcNow.AddDays(1),
                       UserId = UserID,
                       UserToken = GenerateToken().ToString()
                   });        
           
            }
            catch (Exception ex)
            {

                throw ex; 
            }
        }

        private Guid GenerateToken() => Guid.NewGuid();

    }
}
