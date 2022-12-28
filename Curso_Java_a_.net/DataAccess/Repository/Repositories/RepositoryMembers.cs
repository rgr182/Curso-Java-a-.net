using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Dapper.SqlMapper;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class RepositoryMembers<TEntity> : IRepositoryMembers<TEntity> where TEntity : class
    {
        internal SchoolSystemContext _context;

        public RepositoryMembers(SchoolSystemContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new Exception("The entity is null");

           _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }


        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
           // _context.Set<TEntity>().AddOrUpdate(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
