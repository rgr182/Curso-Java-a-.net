using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class TechnologiesService : ITechnologiesService
    {
        readonly ILogger<TechnologiesService> _logger;
        ITechnologiesRepository _TechnologiesRepository;
        public TechnologiesService(ITechnologiesRepository TechnologieRepository, ILogger<TechnologiesService> logger)
        {
            _TechnologiesRepository = TechnologieRepository;
            _logger = logger;
        }

        public async Task<List<Technologies>> GetTechnologiesByName(string Name)
        {
            return await _TechnologiesRepository.GetTechnologiesByName(Name);
        }

        public bool DeleteTechnologiesByName(int technologyId)
        {
            try
            {
               _TechnologiesRepository.DeleteTechnologiesById(technologyId);
               return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }            
        }     

        public Task PutTechnologiesAsync(Technologies name)
        {
            throw new NotImplementedException();
        }

        public void DeleteTechnologies(Technologies name)
        {
            throw new NotImplementedException();
        }

        public Task PostTechnologiesAsync(TechnologyDTO name)
        {
            throw new NotImplementedException();
        }
    }
}
