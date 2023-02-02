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
            builder.Services.AddScoped<IGradesService, GradesService>();
            builder.Services.AddScoped<IMembersService, MembersService>();
            builder.Services.AddScoped<IBootcampCandidatesService, BootcampCandidatesService>();
            builder.Services.AddScoped<ITechnologiesService, TechnologiesService>();
            #endregion

            #region Repositories
            builder.Services.AddScoped<ISessionRepository, SessionRepository>();
            builder.Services.AddScoped<IGradesRepository, GradesRepository>();
            builder.Services.AddScoped<IMemberRepository, MemberRepository>();
            builder.Services.AddScoped<IBootcampCandidatesRepository, BootCampCandidatesRepository>();
            builder.Services.AddScoped<ITechnologiesRepository, TechnologieRepository>();
            #endregion

            #region Utils
            builder.Services.AddScoped<IUtils, Utils.Utils>();
            builder.Services.AddScoped<IAuthUtils, AuthUtils>();
            #endregion
        }
    }
}
