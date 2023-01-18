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
        ITechnologiesRepository _TechnologiesRepository;
        internal SchoolSystemContext _context;
        public TechnologiesService(ITechnologiesRepository TechnologieRepository,
            ILogger<TechnologiesService> logger, SchoolSystemContext context)
        {
            _TechnologiesRepository = TechnologieRepository;
            _logger = logger;
            _context = context;
        }

        public async Task<List<Technologies>> GetTechnologiesByName(string Name)
        {
            return await _TechnologiesRepository.GetTechnologiesByName(Name);
        }

        public async Task<Technologies> DeleteTechnologiesById(int technologyId)
        {
            try
            {
                Technologies tech = await _context.Technologies.FindAsync(technologyId);
                _context.Technologies.Remove(tech);
                _context.SaveChanges();
                return tech;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public Task<Technologies> PutTechnologiesAsync(TechnologyDTO name) => throw new NotImplementedException();

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
