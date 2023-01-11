using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
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

        public Task<Members> GetMember(int id) =>
              _context.Members
                 .Where(x => x.MembersId == id)
                 .FirstOrDefaultAsync();

        public Task<Members> GetMemberById(string usuario, string pass) =>
              _context.Members
                .Where(x => x.Name == usuario && x.Password == pass)
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

        public async Task<Members> PostMembers(MemberDTO members)
        {
            var member = members.Map();
            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task<Members> UpdateMembers(MemberDTO member)
        {
            var memberUpdated = member.Map();         
            _context.Members.Update(memberUpdated);
            await _context.SaveChangesAsync();
            return memberUpdated;
        }

        public async Task<Members> DeleteMembers(int membersId)
        {
            Members member = _context.Members.Find(membersId);
            _context.Members.Remove(member);
            _context.SaveChanges();
            return member;
        }
    }
}
