using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class BootcampCandidatesService : IBootcampCandidatesService
    {
        readonly ILogger<BootcampCandidatesService> _logger;
        readonly IBootcampCandidatesRepository _BootcampCandidatesRepository;
        internal SchoolSystemContext _context;
        
        public BootcampCandidatesService(IBootcampCandidatesRepository bootcampCandidatesRepository,
                              ILogger<BootcampCandidatesService> logger, SchoolSystemContext context)
        {
            _BootcampCandidatesRepository = bootcampCandidatesRepository;
            _logger = logger;
            _context = context;
        }


        public async Task<List<BootcampCandidates>> GetBootcampCandidate(int bootcampCandidateId)
        {
            try
            {
               return _context.BootcampCandidates.ToList();
    }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on Member Service");
                throw ex;
            }
        }
        public async Task<BootcampCandidates> DeleteBootcampCandidate(int bootcampCandidateId)
        {
            try
            {
                BootcampCandidates bootcampCandidate = _context.BootcampCandidates.Find(bootcampCandidateId);
                 _context.BootcampCandidates.Remove(bootcampCandidate);
                 _context.SaveChanges();
                return bootcampCandidate;
                
                if (bootcampCandidate == null)
                {
                    throw new UnauthorizedAccessException();
                }
                return bootcampCandidate;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on bootcampCandidates Service");
                throw ex;
            }
        }

        public async Task<BootcampCandidates> PostBootcampCandidate(BootcampCandidatesDTO name)
        {
            try
            {
                var postBootcampCandidate = name.Map();
                await _context.BootcampCandidates.AddAsync(postBootcampCandidate);
                await _context.SaveChangesAsync();
                return postBootcampCandidate;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<BootcampCandidates> UpdateBootcampCandidate(BootcampCandidatesDTO name)
        {
            try
            {
                var updatedBootcampCandidate = name.Map();
                await _context.BootcampCandidates.AddAsync(updatedBootcampCandidate);
                await _context.SaveChangesAsync();
                return updatedBootcampCandidate;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
