using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        public Task<Users> GetUserById(int id);
        public Task<Users> PostUser(Users user);
        public Task<Users> PutUser(Users user);
        public Task<Users> DeleteUser(int id);
    }
}
