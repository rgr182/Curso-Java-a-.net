using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class TechnologiesService : ITechnologiesService
    {
        readonly ILogger<TechnologiesService> _logger;
        readonly ITechnologiesRepository _TechnologiesRepository;
        public TechnologiesService(ITechnologiesRepository TechnologieRepository,
            ILogger<TechnologiesService> logger)
        {
            _TechnologiesRepository = TechnologieRepository;
            _logger = logger;
        }

        public async Task<Technologies> GetTechnologyAsync(int technologyId)
        {
            try
            {
                Technologies tech = await _TechnologiesRepository.GetTechnologyAsync(technologyId);
                return tech;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on Technologies Service");
                throw ex;
            }
        }

        public async Task<List<Technologies>> GetTechnologiesAsync()
        {
            try
            {
                List<Technologies> tech = await _TechnologiesRepository.GetTechnologiesAsync();
                return tech;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on Technologies Service");
                throw ex;
            }
        }

        public async Task<Technologies> DeleteTechnologiesById(int technologyId)
        {
            try
            {
                Technologies tech = await _TechnologiesRepository.DeleteTechnologiesById(technologyId);
                return tech;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on Technologies Service");
                throw;
            }
        }

        public async Task<Technologies> UpdateTechnologiesAsync(TechnologyDTO name)
        {
            try
            {
                Technologies tech = await _TechnologiesRepository.UpdateTechnologiesAsync(name);
                return tech;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on Technologies Service");
                throw;
            }
        }

        public async Task<Technologies> PostTechnologiesAsync(TechnologyDTO name) 
        {
            try
            {
                Technologies tech = await _TechnologiesRepository.PostTechnologiesAsync(name);
                return tech;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on Technologies Service");
                throw;
            }

        } 
    }
}
