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
        public TechnologieRepository(SchoolSystemContext context)
        {
            _context = context;
        }

        public async Task DeleteTechnologiesById(int technologyId)
        {
            var tech = await _context.Technologies.FindAsync(technologyId);
            if (tech != null)
            {
                _context.Technologies.Remove(tech);
            }
            else
            {
                throw new Exception("Member already deleted");
            }            
            await _context.SaveChangesAsync();
        }

        public Task<List<Technologies>> GetTechnologiesByName(string name)
           => _context.Technologies.Where(x => x.Name.ToLower()
              .Contains(name.ToLower())).ToListAsync();

        public async Task<Technologies> PostTechnologiesAsync(TechnologyDTO name)
        {
            var postTech = name.Map();
            await _context.Technologies.AddAsync(postTech);
            await _context.SaveChangesAsync();
            return postTech;
        }

        public async Task<Technologies> UpdateTechnologiesAsync(TechnologyDTO tech)
        {
            var techUpdated = tech.Map();
            _context.Technologies.Update(techUpdated);
            await _context.SaveChangesAsync();
            return techUpdated;
        }
    }
}