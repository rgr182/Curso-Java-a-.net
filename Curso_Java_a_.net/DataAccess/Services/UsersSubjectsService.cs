using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class UsersSubjectsService : IUsersSubjectsService
    {
        readonly ILogger<SubjectsService> logger;
        IUsersSubjectsRepository _usersSubjectsRepository;
        public UsersSubjectsService(IUsersSubjectsRepository usersSubjectsRepository, ILogger<SubjectsService> logger)
        {
            _usersSubjectsRepository = usersSubjectsRepository;
            this.logger = logger;
        }

        public void DeleteUserSubject(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UsersSubjects> GetUserSubjectById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<result>> GetUserSubjects(int id)
        {
            try
            {
                return _usersSubjectsRepository.GetUserSubjects(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in UsersService");
                throw ex;
            }
        }

        public void PostUserSubject(UsersSubjects userSubject)
        {
            throw new NotImplementedException();
        }

        public void PutUserSubject(UsersSubjects userSubject)
        {
            throw new NotImplementedException();
        }
    }
}
