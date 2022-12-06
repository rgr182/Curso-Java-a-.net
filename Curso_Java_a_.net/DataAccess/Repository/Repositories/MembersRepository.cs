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

        //public void DeleteUser(int id)
        //{
        //    //Members Members = _context.Members.Find(id);
        //    //_context.Members.Remove(Member);
        //    //_context.SaveChanges();
        //}

        public Task<Members> GetMemberById(string usuario, string pass)
        {
            return _context.Members
                .Where(x => x.Name  == usuario && x.Password == pass)
                .FirstOrDefaultAsync();
        }

        //public void PostMember(Members user)
        //{
        //    _context.Members
        //        .AddAsync(user);
        //}

        //public void PutMember(Members user)
        //{
        //    throw new NotImplementedException();
        //}
    }   
}
