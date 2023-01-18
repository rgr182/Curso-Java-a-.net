using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces
{
    public interface IClassesRepository
    {
        public Task<Groups> GetGroupStudent();
    }
}
