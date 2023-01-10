using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface IAvatarUsersRepository
    {
        public Task<Users> GetUserById(int id);
        public Task<Users> LoginUser(string user, string password);
        public void PostUser(Users user);
        public void PutUser(Users user);
        public void DeleteUser(int id);
    }
}
