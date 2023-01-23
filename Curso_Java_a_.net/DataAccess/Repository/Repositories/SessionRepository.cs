using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        internal SchoolSystemContext _context;

        public SessionRepository(SchoolSystemContext context)
        {
            _context = context;
        }

        public Task<Sessions> GetSession(int UserId)
        {
            return _context.Sessions
                .Where(u => u.MemberId == UserId)
                .OrderBy(x => x.MemberId)
                .LastAsync();
        }

        public async Task AddSession(Sessions session)
        {
             await _context.Sessions.AddAsync(session);
             await _context.SaveChangesAsync();
        }      
    }
}
