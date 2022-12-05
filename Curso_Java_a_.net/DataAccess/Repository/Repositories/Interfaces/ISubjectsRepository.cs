using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface ISubjectsRepository
    {
        public Task<Subjects> GetSubjectById(int id);
        public void PostSubject(Subjects subject);
        public void PutSubject(Subjects subject);
        public void DeleteSubject(int id);
    }
}
