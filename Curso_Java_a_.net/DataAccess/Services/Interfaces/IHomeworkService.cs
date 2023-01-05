using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Repositories;

namespace Curso_Java_a_.net.DataAccess.Services.Interfaces
{
    public interface IHomeworkService
    {
        public Task<Homework> GetHomeworksByActivityId(long Id);
        public Task<Homework> GetHomework(long UserId);
        //public Task<List<Homework>> GetHomeworks(long UserId, long GroupId, bool isActive, string OrderDate, string Status);
        public Task<List<HomeworkRepository.resultado>> GetHomeworks(long UserId, int Role, long GroupId, bool isActive, string OrderDate, string Status);
    }
}
