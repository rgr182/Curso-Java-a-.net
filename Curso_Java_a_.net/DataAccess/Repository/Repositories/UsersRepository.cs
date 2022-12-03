using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        internal SchoolSystemTestContext _context;
        public UsersRepository(SchoolSystemTestContext context)
        {
            _context = context;
        }

        public void DeleteUser(int id)
        {
            Users user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public Task<Users> GetUserById(string usuario, string pass)
        {
            return _context.Users
                .Where(x => x.Name  == usuario && x.UserPassword == pass)
                .FirstOrDefaultAsync();
        }

        public void PostUser(Users user)
        {
            _context.Users
                .AddAsync(user);
        }

        public void PutUser(Users user)
        {
            throw new NotImplementedException();
        }
    }   
}
