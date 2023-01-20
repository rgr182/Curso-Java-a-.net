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

        public Task<Member> GetMember(int id) =>
              _context.Member
                 .Where(x => x.MembersId == id)
                 .FirstOrDefaultAsync();

        public Task<Member> GetMemberById(string usuario, string pass) =>
              _context.Member
                .Where(x => x.User == usuario && x.Password == pass)
                .FirstOrDefaultAsync();

        public async Task<List<Member>> GetMember()
        {
            return await _context.Member.ToListAsync();
        }

        public async Task SaveMemberAsync(Member member)
        {
            await _context.Member.AddAsync(member);
            await _context.SaveChangesAsync();
        }

        public async Task<Member> PostMember(MemberDTO members)
        {
            var member = members.Map();
            await _context.Member.AddAsync(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task<Member> UpdateMember(MemberDTO member)
        {
            var memberUpdated = member.Map();         
            _context.Member.Update(memberUpdated);
            await _context.SaveChangesAsync();
            return memberUpdated;
        }

        public async Task<Member> DeleteMember(int membersId)
        {
            Member member = _context.Member.Find(membersId);
            _context.Member.Remove(member);
            _context.SaveChanges();
            return member;
        }
    }
}
