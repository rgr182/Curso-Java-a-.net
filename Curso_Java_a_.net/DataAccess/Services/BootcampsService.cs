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
        public BootcampsService(IBootcampsRepository bootcampsRepository,
                              ILogger<BootcampsService> logger)
        {
            _BootcampsRepository = bootcampsRepository;
            _logger = logger;
        }
        public async Task<Bootcamps> GetBootcamps(int bootcampId)
        {
            try
            {
                Bootcamps bootcamp = await _BootcampsRepository.GetBootcamps(bootcampId);
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
                List<Bootcamps> bootcamp = await _BootcampsRepository.GetBootcamps();
                return bootcamp;
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
                Bootcamps bootcamp = await _BootcampsRepository.DeleteBootcamps(bootcampId);
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
                var postBootcamp = await _BootcampsRepository.PostBootcamps(name);
                return postBootcamp;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on Bootcamps Service");
                throw;
            }
        }

        public async Task<Bootcamps> UpdateBootcamps(BootcampsDTO name)
        {
            try
            {
                var updatedBootcamp = await _BootcampsRepository.UpdateBootcamps(name);
                return updatedBootcamp;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on Bootcamps Service");
                throw;
            }
        }
    }
}
