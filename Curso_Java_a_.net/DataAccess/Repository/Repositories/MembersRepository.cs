using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using static Dapper.SqlMapper;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class MembersRepository : IMembersRepository
    {
        internal SchoolSystemContext _context;
        public MembersRepository(SchoolSystemContext context)
        {
            _context = context;
        }



       public Task<Members> GetMember(int id)
        {
            return _context.Members
                .Where(x => x.MembersId == id)
                .FirstOrDefaultAsync();
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
        


        public async Task<Members> PostMembers(Members members)
        {
            await _context.Members.AddAsync(members);
            await _context.SaveChangesAsync();
            return members;
            
        }

        public async Task<Members> UpdateMembers(Members members)
        {
            var res= "";
           
            Members members1 = _context.Members.Find(members.MembersId);
            members1.Name = members.Name;
            members1.FirstName = members.FirstName;
            members1.SecondName = members.SecondName;
            members1.CurrentLocationId = members.CurrentLocationId;
            members1.MemberRegistratior =  members.MemberRegistratior;
            members1.Email = members.Email;
            members1.User= members.User;
            members1.Password = members.Password;   
            _context.Members.Update(members1);
            await _context.SaveChangesAsync();
            return members1; 
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



