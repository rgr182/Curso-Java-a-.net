using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class SubjectsService : ISubjectsService
    {
        readonly ILogger<SubjectsService> logger;
        ISubjectsRepository _subjectsRepository;
        public SubjectsService(ISubjectsRepository subjectsRepository, ILogger<SubjectsService> logger)
        {
            _subjectsRepository = subjectsRepository;
            this.logger = logger;
        }

        public void DeleteSubject(int id)
        {
            try
            {
                _subjectsRepository.DeleteSubject(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }

        public Task<Subjects> GetSubjectById(int id)
        {
            try
            {
                return _subjectsRepository.GetSubjectById(id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return null;
            }
        }

        public void PostSubject(Subjects subject)
        {
            try
            {
                _subjectsRepository.PostSubject(subject);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }

        public void PutSubject(Subjects subject)
        {
            try
            {
                _subjectsRepository.PutSubject(subject);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }
    }
}
