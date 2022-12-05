using Curso_Java_a_.net.DataAccess.Entities;
using static Curso_Java_a_.net.DataAccess.Repository.Repositories.UsersSubjectsRepository;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface IUsersSubjectsRepository
    {
        public Task<UsersSubjects> GetUserSubjectById(int id);
        public Task<List<result>> GetUserSubjects(int id);
        public void PostUserSubject(UsersSubjects userSubject);
        public void PutUserSubject(UsersSubjects userSubject);
        public void DeleteUserSubject(int id);
    }
}
