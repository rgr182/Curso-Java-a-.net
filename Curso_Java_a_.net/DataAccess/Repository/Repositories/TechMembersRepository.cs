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

        public async Task<TechMembers> PostTechMemberAsync(TechMembers techMembers)
        {
            await _context.TechMembers.AddAsync(techMembers);
            await _context.SaveChangesAsync();
            return techMembers;
        }

        public async Task<TechMembers> UpdateTechMemberAsync(TechMembers techMember)
        {
            TechMembers techMembers = await _context.TechMembers.FindAsync(techMember.TechMemberId);
            if (techMembers == null)
            {
                return null;
            }
            _context.TechMembers.Update(techMembers);
            await _context.SaveChangesAsync();
            return techMembers;
        }

        public async Task<TechMembers> DeleteTechMemberById(int techMembersId)
        {
            TechMembers techMembers = await _context.TechMembers.FindAsync(techMembersId);
            if (techMembers == null)
            {
                return null;
            }
            _context.TechMembers.Remove(techMembers);
            await _context.SaveChangesAsync();
            return techMembers;
        }
    }
}
