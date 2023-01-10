using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Repositories;
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

        public async Task<List<Tecnologies>> GetTechnologiesByName(string Name)
        {
            return await _TechnologiesRepository.GetTechnologiesByName(Name);
        }

        public async Task<Tecnologies> DeleteTechnologiesByName(string Name)
        {
            try
            {
                await _TechnologiesRepository.DeleteTechnologies(Name);
              
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
        
        


}
