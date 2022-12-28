using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class AppService : ServiceMembers<Members>, IAppService
    {
        public AppService(IAppRepository appRepository ) : base( appRepository )
        {
        }
    }
}
