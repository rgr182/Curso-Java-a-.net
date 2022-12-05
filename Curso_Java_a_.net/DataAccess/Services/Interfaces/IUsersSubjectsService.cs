
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Repositories;
namespace Curso_Java_a_.net.DataAccess.Services.Interfaces
{
    public interface IUsersSubjectsService
    {
        public Task<List<result>> GetUserSubjects(int id);
        public Task<UsersSubjects> GetUserSubjectById(int id);
        public void PostUserSubject(UsersSubjects userSubject);
        public void PutUserSubject(UsersSubjects userSubject);
        public void DeleteUserSubject(int id);
    }
}
