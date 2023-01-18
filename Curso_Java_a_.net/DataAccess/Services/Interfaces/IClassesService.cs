using Curso_Java_a_.net.DataAccess.Entities;

namespace Curso_Java_a_.net.DataAccess.Services.Interfaces
{
    public interface IClassesService
    {
        public Task<Groups> GetGroupStudent();
    }
}
