using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Curso_Java_a_.net.DataAccess.Repository.Repositories
{
    public class BootCampCandidatesRepository : IBootcampCandidatesRepository
    {
        internal SchoolSystemContext _context;
        public BootCampCandidatesRepository(SchoolSystemContext context)
        {
            _context = context;
        }

        public async Task<List<BootcampCandidates>> GetBootcampCandidates()
        {
            return await _context.BootcampCandidates.ToListAsync();
        }

        public Task<BootcampCandidates> GetBootcampCandidate(int bootcampCandidateId) =>
            _context.BootcampCandidates
           .Where(x => x.BootcampCandidateId == bootcampCandidateId)
              .FirstOrDefaultAsync();

        public async Task<BootcampCandidates> PostBootcampCandidate(BootcampCandidates bootcampCandidateId)
        {
            await _context.BootcampCandidates.AddAsync(bootcampCandidateId);
            await _context.SaveChangesAsync();
            return bootcampCandidateId;
        }

        public async Task<BootcampCandidates> UpdateBootcampCandidate(BootcampCandidates bootcampCandidateId)
        {
            await _context.BootcampCandidates.FindAsync(bootcampCandidateId);
            _context.BootcampCandidates.Update(bootcampCandidateId);
            await _context.SaveChangesAsync();
            return bootcampCandidateId;
        }

        public async Task<BootcampCandidates> DeleteBootcampCandidate(int bootcampCandidateId)
        {
            BootcampCandidates deleteBootcampCandidate = _context.BootcampCandidates.Find(bootcampCandidateId);
            _context.BootcampCandidates.Remove(deleteBootcampCandidate);
            _context.SaveChanges();
            return deleteBootcampCandidate;
        }
    }
}
