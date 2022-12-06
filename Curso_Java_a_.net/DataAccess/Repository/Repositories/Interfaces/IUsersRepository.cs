using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        public Task<Users> GetUserById(string user, string pass);
        public void PostUser(Users user);
        public void PutUser(Users user);
        public void DeleteUser(int id);
    }
}
