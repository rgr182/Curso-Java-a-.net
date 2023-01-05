using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using Curso_Java_a_.net.Utils.Interfaces;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class SessionService : ISessionService
    {
        readonly ILogger<UsersService> _logger;
        readonly ISessionRepository _sessionRepository;
        readonly IAuthUtils _authUtils;

        public SessionService(ILogger<UsersService> logger,
                              ISessionRepository securityRepository,
                              IAuthUtils authUtils)
        {
            _logger = logger;
            _sessionRepository = securityRepository;
            _authUtils = authUtils;
        }

        public async Task<Session> GetSession(long UserId)
        {
            Session result = new Session();

            try
            {
                result = await _sessionRepository.GetSession(UserId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "some error happened on SessionService");
                throw;
            }

            return result;
        }

        public async Task<Session> SaveSession(Users user)
        {
            try
            {
                var session = new Session()
                {
                    CreationDate = DateTime.UtcNow,
                    ExpirationDate = DateTime.UtcNow.AddDays(1),
                    UserId = user.id,
                    UserToken = _authUtils.GenerateJWT(user)
                }; 

                return session;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
