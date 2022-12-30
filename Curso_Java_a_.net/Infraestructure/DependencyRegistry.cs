using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Repository.Repositories;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using Curso_Java_a_.net.DataAccess.Services;
using Curso_Java_a_.net.Utils.Interfaces;
using Curso_Java_a_.net.Utils.Security;

namespace Curso_Java_a_.net.Infraestructure
{
    public class DependencyRegistry
    {
        public DependencyRegistry(WebApplicationBuilder builder)
        {
            #region Services
            builder.Services.AddScoped<ISessionService, SessionService>();
            builder.Services.AddScoped<IUsersService, UsersService>();
            #endregion

            #region Repositories
            builder.Services.AddScoped<ISessionRepository, SessionRepository>();
            builder.Services.AddScoped<IUsersRepository, UsersRepository>();
            #endregion

            #region Utils
            builder.Services.AddScoped<IUtils, Utils.Utils>();
            builder.Services.AddScoped<IAuthUtils, AuthUtils>();
            #endregion
        }
    }
}
