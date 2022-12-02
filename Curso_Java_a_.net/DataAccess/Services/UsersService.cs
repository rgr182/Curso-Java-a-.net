using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class UsersService : IUsersService
    {
        readonly ILogger<UsersService> logger;
        IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository, ILogger<UsersService> logger)
        {
            _usersRepository = usersRepository;
            this.logger = logger;
        }
        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Users> GetUserById(int id)
        {
            try
            {
                var user = await _usersRepository.GetUserById(id);
                return user;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in UsersService");
                throw ex;
            }
        }

        public void PostUser(Users user)
        {
            throw new NotImplementedException();
        }

        public void PutUser(Users user)
        {
            throw new NotImplementedException();
        }
    }
}
