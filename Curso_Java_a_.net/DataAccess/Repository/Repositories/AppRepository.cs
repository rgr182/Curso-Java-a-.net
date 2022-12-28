using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class AppRepository : RepositoryMembers<Members>, IAppRepository
    {
        public AppRepository(SchoolSystemContext SchoolSystemContext) : base(SchoolSystemContext)
        {

        }
    }
}
