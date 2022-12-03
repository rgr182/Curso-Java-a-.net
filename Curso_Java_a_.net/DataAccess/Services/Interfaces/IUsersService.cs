
using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Services.Interfaces
{
    public interface IUsersService
    {
        public Task<Users> GetUserByUserAndPassword(string user, string pass);
        //public Task<password> PostUser(Users user);
        public void PutUser(Users user);
        public void DeleteUser(int id);
    }
}
