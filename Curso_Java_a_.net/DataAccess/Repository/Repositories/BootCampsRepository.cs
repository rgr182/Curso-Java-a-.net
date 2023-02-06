using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class BootCampsRepository : IBootcampsRepository
    {
        internal SchoolSystemContext _context;
        public BootCampsRepository(SchoolSystemContext context)
        {
            _context = context;
        }
        public async Task<List<Bootcamps>> GetBootcamps()
        {
            return await _context.Bootcamps.ToListAsync();
        }

        public async Task<Bootcamps> GetBootcamps(int bootcampId) =>
          
            await _context.Bootcamps
           .Where(x => x.BootcampId == bootcampId)
              .FirstOrDefaultAsync();

        public async Task<Bootcamps> PostBootcamps(BootcampsDTO name)
        {
            var postBootcamp = name.Map();
            await _context.Bootcamps.AddAsync(postBootcamp);
            await _context.SaveChangesAsync();
            return postBootcamp;
        }

        public async Task<Bootcamps> UpdateBootcamps(BootcampsDTO name)
        { 
            var updatedBootcamp = name.Map();
            await _context.Bootcamps.AddAsync(updatedBootcamp);
            await _context.SaveChangesAsync();
            return updatedBootcamp;
        }

        public async Task<Bootcamps> DeleteBootcamps(int bootcampId)
        {
            Bootcamps deleteBootcamp = await _context.Bootcamps.FindAsync(bootcampId);
            _context.Bootcamps.Remove(deleteBootcamp);
            _context.SaveChanges();
            return deleteBootcamp;
        }
    }
}
