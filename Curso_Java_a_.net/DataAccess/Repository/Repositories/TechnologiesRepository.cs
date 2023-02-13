using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class TechnologiesRepository : ITechnologiesRepository
    {
        internal SchoolSystemContext _context;
        public TechnologiesRepository(SchoolSystemContext context)
        {
            _context = context;
        }
        public async Task<Technologies> GetTechnologyAsync(int technologyId) => 
           await _context.Technologies
           .Where(x => x.TechnologyId == technologyId)
              .FirstOrDefaultAsync();

        public async Task<List<Technologies>> GetTechnologiesAsync()
        {
            return await _context.Technologies.ToListAsync();
        }
        public async Task<Technologies> PostTechnologiesAsync(TechnologyDTO tech)
        {
            var postTech = tech.Map();
            await _context.Technologies.AddAsync(postTech);
            await _context.SaveChangesAsync();
            return postTech;
        }
        public async Task<Technologies> UpdateTechnologiesAsync(TechnologyDTO tech)
        {
            var techToUpdate = tech.Map();
            _context.Technologies.Update(techToUpdate);
            await _context.SaveChangesAsync();
            return techToUpdate;
        }
        public async Task<Technologies> DeleteTechnologiesById(int technologyId)
        {
            Technologies tech = await _context.Technologies.FindAsync(technologyId);
            if (tech == null)
            {
                return null;
            }
            _context.Technologies.Remove(tech);
            await _context.SaveChangesAsync();
            return tech;
        }
    }
}
