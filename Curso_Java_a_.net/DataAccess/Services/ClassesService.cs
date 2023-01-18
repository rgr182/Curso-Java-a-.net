using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class ClassesService
    {
        readonly ILogger<ClassesService> logger;
        IClassesRepository _classesRepository;

        public ClassesService(IClassesRepository classesRepository, ILogger<ClassesService> logger)
        {
            _classesRepository = classesRepository;
            this.logger = logger;
        }

        public Task<Groups> GetGroupStudent()
        {
            try
            {
                return _classesRepository.GetGroupStudent();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return null;
            }
        }
    }
}
