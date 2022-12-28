using Curso_Java_a_.net.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface IRepositoryMembers<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(int id);

        Task<TEntity> Insert(TEntity entity);
          Task<TEntity> Update(TEntity entity);
         Task Delete(int id);
    }
}
