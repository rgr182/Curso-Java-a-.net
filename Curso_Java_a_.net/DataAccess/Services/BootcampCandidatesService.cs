using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class BootcampCandidatesService : IBootcampCandidatesService
    {
        readonly ILogger<BootcampCandidatesService> _logger;
        readonly IBootcampCandidatesRepository _BootcampCandidatesRepository;
        public BootcampCandidatesService(IBootcampCandidatesRepository bootcampCandidatesRepository,
                              ILogger<BootcampCandidatesService> logger)
        {
            _BootcampCandidatesRepository = bootcampCandidatesRepository;
            _logger = logger;
        }
        public async Task<BootcampCandidates> GetBootcampCandidate(int bootcampCandidateId)
        {
            try
            {
                BootcampCandidates bootcamper = await _BootcampCandidatesRepository.GetBootcampCandidate(bootcampCandidateId);
                return bootcamper;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public async Task<List<BootcampCandidates>> GetBootcampCandidates()
        {
            try
            {
                List<BootcampCandidates> grades = await _BootcampCandidatesRepository.GetBootcampCandidates();
                return grades;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
        public async Task<BootcampCandidates> DeleteBootcampCandidate(int bootcampCandidateId)
        {
            try
            {
                BootcampCandidates bootcampCandidate = await _BootcampCandidatesRepository.DeleteBootcampCandidate(bootcampCandidateId);
                return bootcampCandidate;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public async Task<BootcampCandidates> PostBootcampCandidate(BootcampCandidatesDTO bootcampCandidateId)
        {
            try
            {
                var bootCampCandidate = await _BootcampCandidatesRepository.PostBootcampCandidate(bootcampCandidateId);
                return bootCampCandidate;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<BootcampCandidates> UpdateBootcampCandidate(BootcampCandidatesDTO bootcampCandidateId)
        {
            try
            {
                var bootCampCandidate = await _BootcampCandidatesRepository.UpdateBootcampCandidate(bootcampCandidateId);
                return bootCampCandidate;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
