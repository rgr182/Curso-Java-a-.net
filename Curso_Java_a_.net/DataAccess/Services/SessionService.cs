using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using Curso_Java_a_.net.Utils.Interfaces;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class SessionService : ISessionService
    {
        readonly ILogger<MembersService> _logger;
        readonly ISessionRepository _securityRepository;
        readonly IUtils _utils;

        public SessionService(ILogger<MembersService> logger,
                              ISessionRepository securityRepository,
                              IUtils utils)
        {
            _logger = logger;
            _securityRepository = securityRepository;
            _utils = utils;
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
                       UserToken = _utils.GenerateTokenString()
                   });            
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
