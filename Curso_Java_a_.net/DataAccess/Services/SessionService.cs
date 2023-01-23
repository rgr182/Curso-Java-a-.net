using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using Curso_Java_a_.net.Utils.Interfaces;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class SessionService : ISessionService
    {
        readonly ILogger<MembersService> _logger;
        readonly ISessionRepository _sessionRepository;
        readonly IAuthUtils _authUtils;

        public SessionService(ILogger<MembersService> logger,
                              ISessionRepository securityRepository,
                              IAuthUtils authUtils)
        {
            _logger = logger;
            _sessionRepository = securityRepository;
            _authUtils = authUtils;
        }

        public async Task<Sessions> GetSession(int UserId)
        {
            Sessions result = new Sessions();

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

        public async Task<Sessions> SaveSession(Members user)
        {
            try
            {
                var session = new Sessions()
                {
                    CreationDate = DateTime.UtcNow,
                    ExpirationDate = DateTime.UtcNow.AddDays(1),
                    MemberId = user.MemberId,
                    UserToken = _authUtils.GenerateJWT(user)
                }; 

                await _sessionRepository
                   .AddSession(session);

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
