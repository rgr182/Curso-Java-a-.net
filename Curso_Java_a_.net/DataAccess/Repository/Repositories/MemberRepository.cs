using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        internal SchoolSystemContext _context;
        public MemberRepository(SchoolSystemContext context)
        {
            _context = context;
        }

        public async Task<Members> GetMember(int id) =>
              await _context.Members
                 .Where(x => x.MemberId == id)
                 .FirstOrDefaultAsync();

        public async Task<Members> GetMemberByUserAndPassword(string usuario, string pass) =>
              await _context.Members
                .Where(x => x.User == usuario && x.Password == pass)
                .FirstOrDefaultAsync();

        public async Task<List<Members>> GetMembers()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task SaveMemberAsync(Members member)
        {
            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();
        }

        public async Task<Members> PostMember(MemberDTO members)
        {
            var member = members.Map();
            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task<Members> UpdateMember(MemberDTO member)
        {
            var memberUpdated = member.Map();
            var memberToUpdate = await _context.Members.FindAsync(member.MemberId);
            if (memberToUpdate == null)
            {
                return null;
            }
            _context.Members.Update(memberUpdated);
            await _context.SaveChangesAsync();
            return memberUpdated;
        }

        public async Task<Members> DeleteMember(int memberId)
        {
            Members member = await _context.Members.FindAsync(memberId);
            if (member == null)
            {
                return null;
            }
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
            return member;
        }
    }
}
