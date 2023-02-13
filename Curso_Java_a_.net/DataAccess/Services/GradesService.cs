using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using System.Diagnostics.Metrics;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class GradesService : IGradesService
    {
        readonly ILogger<GradesService> _logger;
        readonly IGradesRepository _gradesRepository;
        public GradesService(IGradesRepository gradesRepository, ILogger<GradesService> logger)
        {
            _gradesRepository = gradesRepository;
            _logger = logger;
        }
        public async Task<Grades> GetGrade(int memberId)
        {
            try
            {
                var member = await _gradesRepository.GetGrade(memberId);
                return member;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public async Task<List<Grades>> GetGrades()
        {
            try
            {
                List<Grades> grades = await _gradesRepository.GetGrades();
                return grades;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        public async Task<Grades> PostGradesAsync(Grades memberId)
        {
            try
            {
                await _gradesRepository.PostGradesAsync(memberId);
                return memberId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<Grades> UpdateGradesAsync(Grades memberId)
        {
            try
            {
                await _gradesRepository.UpdateGradesAsync(memberId);
                return memberId;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<Grades> DeleteGrades(int memberId)
        {
            try
            {
                var member = await _gradesRepository.DeleteGrades(memberId);
                return member;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
    }
}
