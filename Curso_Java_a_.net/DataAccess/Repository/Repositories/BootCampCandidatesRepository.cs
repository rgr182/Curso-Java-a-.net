using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

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
        public async Task<BootcampCandidates> GetBootcampCandidate(int bootcampCandidateId) =>

            await _context.BootcampCandidates
           .Where(x => x.BootcampCandidateId == bootcampCandidateId)
              .FirstOrDefaultAsync();

        public async Task<BootcampCandidates> PostBootcampCandidate(BootcampCandidatesDTO name)
        {
            var postBootcampCandidate = name.Map();
            await _context.BootcampCandidates.AddAsync(postBootcampCandidate);
            await _context.SaveChangesAsync();
            return postBootcampCandidate;
        }
        public async Task<BootcampCandidates> UpdateBootcampCandidate(BootcampCandidatesDTO name)
        {
            var updatedBootcampCandidate = name.Map();
            await _context.BootcampCandidates.AddAsync(updatedBootcampCandidate);
            await _context.SaveChangesAsync();
            return updatedBootcampCandidate;
        }

        public async Task<BootcampCandidates> DeleteBootcampCandidate(int bootcampCandidateId)
        {
            BootcampCandidates deleteBootcampCandidate = await _context.BootcampCandidates.FindAsync(bootcampCandidateId);
            _context.BootcampCandidates.Remove(deleteBootcampCandidate);
            _context.SaveChanges();
            return deleteBootcampCandidate;
        }
    }
}
