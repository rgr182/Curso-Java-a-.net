using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class TechnologiesService : ITechnologiesService
    {
        readonly ILogger<TechnologiesService> _logger;
        readonly ITechnologiesRepository _TechnologiesRepository;
        internal SchoolSystemContext _context;
        public TechnologiesService(ITechnologiesRepository TechnologieRepository,
            ILogger<TechnologiesService> logger, SchoolSystemContext context)
        {
            _TechnologiesRepository = TechnologieRepository;
            _logger = logger;
            _context = context;
        }

        public async Task<List<Technologies>> GetTechnologiesByNameAsync(string Name)
        {
            return await _TechnologiesRepository.GetTechnologiesByName(Name);
        }

        public async Task DeleteTechnologiesById(int technologyId)
        {
            try
            {
                Technologies tech = await _context.Technologies.FindAsync(technologyId);
                _context.Technologies.Remove(tech);
                _context.SaveChanges();
                return;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<Technologies> UpdateTechnologiesAsync(TechnologyDTO name)
        {
            try
            {
                var techUpdated = name.Map();
                _context.Technologies.Update(techUpdated);
                await _context.SaveChangesAsync();
                return techUpdated;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

          


        public async Task<Technologies> PostTechnologiesAsync(TechnologyDTO name) 
        {
            try
            {
                var postTech = name.Map();
                await _context.Technologies.AddAsync(postTech);
                await _context.SaveChangesAsync();
                return postTech;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }

        } 
    }
}
