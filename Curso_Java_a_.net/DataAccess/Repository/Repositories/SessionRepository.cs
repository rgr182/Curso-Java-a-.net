using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        internal ClubLiaContext _context;

        public SessionRepository(ClubLiaContext context)
        {
            _context = context;
        }

        public Task<Session> GetSession(long UserId)
        {
            return _context.Session
                .Where(u => u.UserId == UserId)
                .OrderBy(x => x.UserId)
                .LastAsync();
        }

        public async Task AddSession(Session session)
        {
             await _context.Session.AddAsync(session);
             await _context.SaveChangesAsync();
        }      
    }
}
