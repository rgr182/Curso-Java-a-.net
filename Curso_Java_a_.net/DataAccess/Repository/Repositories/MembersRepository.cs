using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class MembersRepository : IMembersRepository
    {
        internal SchoolSystemContext _context;
        public MembersRepository(SchoolSystemContext context)
        {
            _context = context;
        }

        public Task<Members> GetMemberById(string usuario, string pass) =>
             _context.Members
                .Where(x => x.Name == usuario && x.Password == pass)
                .FirstOrDefaultAsync();

        public async Task SaveMemberAsync(Members member)
        {
            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();
        }             
    }
}
