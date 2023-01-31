using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class BootCampersRepository : IBootCampersRepository
    {
        internal SchoolSystemContext _context;
        public BootCampersRepository(SchoolSystemContext context)
        {
            _context = context;
        }

        public Task<BootCampers> GetBootCamper(int id) =>
              _context.BootCampers
                 .Where(x => x.BootCamperId == id)
                 .FirstOrDefaultAsync();

        public Task<BootCampers> GetBootCamperByUserAndPassword(string usuario, string pass) =>
              _context.BootCampers
                .Where(x => x.User == usuario && x.Password == pass)
                .FirstOrDefaultAsync();

        public async Task<List<BootCampers>> GetBootCamper()
        {
            return await _context.BootCampers.ToListAsync();
        }

        public async Task SaveBootCamperAsync(BootCampers bootCamper)
        {
            await _context.BootCampers.AddAsync(bootCamper);
            await _context.SaveChangesAsync();
        }

        public async Task<BootCampers> PostBootCamper(BootCamperDTO bootCampers)
        {
            var bootCamper = bootCampers.Map();
            await _context.BootCampers.AddAsync(bootCamper);
            await _context.SaveChangesAsync();
            return bootCamper;
        }

        public async Task<BootCampers> UpdateBootCamper(BootCamperDTO bootCamper)
        {
            var bootCamperUpdated = bootCamper.Map();         
            _context.BootCampers.Update(bootCamperUpdated);
            await _context.SaveChangesAsync();
            return bootCamperUpdated;
        }

        public async Task<BootCampers> DeleteBootCamper(int bootCamperId)
        {
            BootCampers bootCamper = _context.BootCampers.Find(bootCamperId);
            _context.BootCampers.Remove(bootCamper);
            _context.SaveChanges();
            return bootCamper;
        }
    }
}
