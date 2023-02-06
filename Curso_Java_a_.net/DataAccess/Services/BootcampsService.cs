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
    public class BootcampsService : IBootcampsService
    {
        readonly ILogger<BootcampsService> _logger;
        readonly IBootcampsRepository _BootcampsRepository;
        internal SchoolSystemContext _context;

        public BootcampsService(IBootcampsRepository bootcampsRepository,
                              ILogger<BootcampsService> logger, SchoolSystemContext context)
        {
            _BootcampsRepository = bootcampsRepository;
            _logger = logger;
            _context = context;
        }
        public async Task<Bootcamps> GetBootcamps(int bootcampId)
        {
            try
            {
                Bootcamps bootcamp = await _BootcampsRepository.GetBootcamps(bootcampId);
                if (bootcamp == null)
                {
                    throw new UnauthorizedAccessException();
                }
                return bootcamp;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on Bootcamps Service");
                throw ex;
            }
        }
        public async Task<List<Bootcamps>> GetBootcamps()
        {
            try
            {
                return _context.Bootcamps.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on Bootcamps Service");
                throw ex;
            }
        }
        public async Task<Bootcamps> DeleteBootcamps(int bootcampId)
        {
            try
            {
                Bootcamps bootcamp = _context.Bootcamps.Find(bootcampId);
                _context.Bootcamps.Remove(bootcamp);
                _context.SaveChanges();
                return bootcamp;

                if (bootcamp == null)
                {
                    throw new UnauthorizedAccessException();
                }
                return bootcamp;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on bootcamps Service");
                throw ex;
            }
        }

        public async Task<Bootcamps> PostBootcamps(BootcampsDTO name)
        {
            try
            {
                var postBootcamp = name.Map();
                await _context.Bootcamps.AddAsync(postBootcamp);
                await _context.SaveChangesAsync();
                return postBootcamp;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<Bootcamps> UpdateBootcamps(BootcampsDTO name)
        {
            try
            {
                var updatedBootcamp = name.Map();
                await _context.Bootcamps.AddAsync(updatedBootcamp);
                await _context.SaveChangesAsync();
                return updatedBootcamp;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
