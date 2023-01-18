using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class TechnologieRepository : ITechnologiesRepository
    {
        internal SchoolSystemContext _context;
        public TechnologieRepository(SchoolSystemContext context)     {
            _context = context;
        }

        public async Task<Technologies> DeleteTechnologiesById(int technologyId)
        {
            var tech = await _context.Technologies.FindAsync(technologyId);
            _context.Technologies.Remove(tech);
            _context.SaveChanges();
            return tech;
        }

        public Task<List<Technologies>> GetTechnologiesByName(string name)
        {
           return  _context.Technologies
                 .ToListAsync();
        }

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