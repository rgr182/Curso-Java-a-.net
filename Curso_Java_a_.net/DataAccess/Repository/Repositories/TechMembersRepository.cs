using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class TechMembersRepository : ITechMembersRepository
    {
        internal SchoolSystemContext _context;
        public TechMembersRepository(SchoolSystemContext context)
        {
            _context = context;
        }
        public async Task<List<TechMembers>> GetTechMembersAsync()
        {
            return await _context.TechMembers.ToListAsync();
        }

        public async Task<TechMembers> GetTechMemberAsync(int techMembersId) =>
          
            await _context.TechMembers
           .Where(x => x.TechMemberId == techMembersId)
              .FirstOrDefaultAsync();

        public async Task<TechMembers> PostTechMemberAsync(TechMembers techMembersId)
        {
            await _context.TechMembers.AddAsync(techMembersId);
            _context.SaveChanges();
            return techMembersId;
        }

        public async Task<TechMembers> UpdateTechMemberAsync(TechMembers techMembersId)
        {
            TechMembers techMembers = _context.TechMembers.Find(techMembersId);
            _context.TechMembers.Update(techMembers);
            _context.SaveChanges();
            return techMembers;
        }

        public async Task<TechMembers> DeleteTechMemberById(int techMembersId)
        {
            TechMembers techMembers = await _context.TechMembers.FindAsync(techMembersId);
            _context.TechMembers.Remove(techMembers);
            _context.SaveChanges();
            return techMembers;
        }
    }
}
