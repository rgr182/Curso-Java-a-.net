using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class HomeworkService : IHomeworkService
    {
        readonly ILogger<HomeworkService> logger;
        IHomeworkRepository _homeworkRepository;
        public HomeworkService(IHomeworkRepository homeworkRepository, ILogger<HomeworkService> logger)
        {
            _homeworkRepository = homeworkRepository;
            this.logger = logger;
        }

        public Task<Homework> GetHomework(long UserId)
        {
            throw new NotImplementedException();
        }
        public Task<List<Homework>> GetHomeworks(long UserId, long GroupId, bool isActive, string OrderDate, string Status)
        {
            throw new NotImplementedException();
        }

        public Task<List<HomeworkRepository.resultado>> GetHomeworks(long UserId, int Role, long GroupId, bool isActive, string OrderDate, string Status)
        {
            try
            {
                return _homeworkRepository.GetHomeworks(UserId, Role,GroupId, isActive, OrderDate, Status);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<Homework> GetHomeworksByActivityId(long Id)
        {
            throw new NotImplementedException();
        }
    }
}
