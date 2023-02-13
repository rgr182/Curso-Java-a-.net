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

        public async Task<List<TechMembersDTO>> GetTechsMemberAsync(int memberId)
        {
            var result = (from tm in _context.TechMembers
                          join s in _context.Seniorities
                              on tm.SeniorityId equals s.SeniorityId
                          join t in _context.Technologies
                              on tm.TechnologyId equals t.TechnologyId
                          where tm.MemberId == memberId
                          select new
                          {
                              TechMemberId = tm.TechMemberId,
                              MemberId = tm.MemberId,
                              Tech = t.Name,
                              Seniority = s.Name
                          });
            
            List<TechMembersDTO> techMembersDTOs = new List<TechMembersDTO>();
            foreach (var item in result)
            {
                TechMembersDTO techMembers = new TechMembersDTO();
                #region ManualMapping
                techMembers.TechMemberId = item.TechMemberId;
                techMembers.MemberId = item.MemberId;
                techMembers.Tech = item.Tech;
                techMembers.Seniority = item.Seniority;
                #endregion
                techMembersDTOs.Add(techMembers);
            }
            return techMembersDTOs;
        }
    }
}
