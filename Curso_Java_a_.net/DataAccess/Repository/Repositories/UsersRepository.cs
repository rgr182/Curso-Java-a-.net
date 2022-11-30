using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using System.Data.Entity;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        internal SchoolSystemTestContext _context;
        public UsersRepository(SchoolSystemTestContext context)
        {
            _context = context;
        }

        public Task<Users> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Users> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Users> PostUser(Users user)
        {
            throw new NotImplementedException();
        }

        public Task<Users> PutUser(Users user)
        {
            throw new NotImplementedException();
        }
    }   
}
