using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class TechnologieRepository : ITechnologiesRepository
    {
        internal SchoolSystemContext _context;
        public TechnologieRepository(SchoolSystemContext context)     {
            _context = context;
        }

        public async Task DeleteTechnologiesById(int TechnologyId)
        {
            var Technology = await _context.Technologies
                .Where(t => t.TechnologyId == TechnologyId)
                .FirstOrDefaultAsync();

            _context.Technologies.Remove(Technology);

            _context.SaveChanges();            
        }

        public Task<List<Technologies>> GetTechnologiesByName(string name)
        {
           return  _context.Technologies
                 .ToListAsync();
        }

        public async Task<Technologies> PostTechnologiesAsync(Technologies name)
        {
            await _context.Technologies.AddAsync(name);
            await _context.SaveChangesAsync();
            return name;
        }

        public async Task<Technologies> UpdateTechnologiesAsync(TechnologyDTO tech)
        {
            var techUpdated = tech.Map();
            _context.Technologies.Update(techUpdated);
            await _context.SaveChangesAsync();
            return techUpdated;
        }

        bool ITechnologiesRepository.DeleteTechnologiesById(int technologyId)
        {
            throw new NotImplementedException();
        }
    }
}
