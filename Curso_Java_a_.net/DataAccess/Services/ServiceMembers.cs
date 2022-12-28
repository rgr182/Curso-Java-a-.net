using Curso_Java_a_.net.DataAccess.Repository.Repositories;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class ServiceMembers<TEntity> : IServiceMembers<TEntity> where TEntity : class
    {
        private IRepositoryMembers<TEntity> repositoryMembers;

        public ServiceMembers(IRepositoryMembers<TEntity> repositoryMembers)
        {
            this.repositoryMembers = repositoryMembers;
        }

        public async Task Delete(int id)
          {
            await repositoryMembers.Delete(id);
          }

          public async Task<IEnumerable<TEntity>> GetAll()
          {
              return await repositoryMembers.GetAll();
          }

        public async Task<TEntity> GetById(int id)
        {
            return await repositoryMembers.GetById(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            return await repositoryMembers.Insert(entity);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            return await repositoryMembers.Update(entity);
        }
    }
}
