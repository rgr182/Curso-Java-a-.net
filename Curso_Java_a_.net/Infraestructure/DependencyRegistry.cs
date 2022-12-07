using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Repository.Repositories;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using Curso_Java_a_.net.DataAccess.Services;
using Curso_Java_a_.net.Utils.Interfaces;

namespace Curso_Java_a_.net.Infraestructure
{
    public class DependencyRegistry
    {
        public DependencyRegistry(WebApplicationBuilder builder)
        {
            #region Services
            builder.Services.AddScoped<ISessionService, SessionService>();
            builder.Services.AddScoped<IGradesService, GradesService>();
            builder.Services.AddScoped<IMembersService, MembersService>();
            #endregion

            #region Repositories
            builder.Services.AddScoped<ISessionRepository, SessionRepository>();
            builder.Services.AddScoped<IGradesRepository, GradesRepository>();
            builder.Services.AddScoped<IMembersRepository, MembersRepository>();
            #endregion

            #region Utils
            builder.Services.AddScoped<IUtils, Utils.Utils>();
            #endregion
        }
    }
}
