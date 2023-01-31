using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Curso_Java_a_.net.DataAccess.Services
{
    public class BootCampersService : IBootCampersService
    {
        readonly ILogger<BootCampersService> _logger;
        readonly IBootCampersRepository _bootCampersRepository;
        internal SchoolSystemContext _context;
        
        public BootCampersService(IBootCampersRepository bootCampersRepository,
                              ILogger<BootCampersService> logger, SchoolSystemContext context)
        {
            _bootCampersRepository = bootCampersRepository;
            _logger = logger;
            _context = context;
        }      
        
        public async Task<BootCampers> GetBootCamperByUserAndPassword(string usuario, string pass)
        {
            try
            {
                BootCampers member = await _bootCampersRepository.GetBootCamperByUserAndPassword(usuario,  pass);
                if (member == null)
                {
                    throw new UnauthorizedAccessException();
                }

                return member;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in BootCamperService");
                throw ex;
            }
        }
        
        public async Task<BootCampers> SaveBootCampersAsync(BootCampers member)
        {
            try
            {
               await _bootCampersRepository.SaveBootCamperAsync(member);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on BootCamper Service");
                throw ex;
            }

            return member;
        }

        public async Task<BootCampers> GetBootCamper(int memberId)
        {
            try
            {
                BootCampers member = await _bootCampersRepository.GetBootCamper(memberId);
                if (member == null)
                {
                    throw new UnauthorizedAccessException();
                }
                return member;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on BootCamper Service");
                throw ex;
            }
        }
        public async Task<List<BootCampers>> GetBootCampers()
        {
            try
            {
                List<BootCampers> bootCamper = await _bootCampersRepository.GetBootCamper();
                return bootCamper;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on BootCamper Service");
                throw ex;
            }
        }

        public async Task<BootCampers> DeleteBootCampers(int BootCamperId)
        {
            try
            {
                BootCampers member = _context.BootCampers.Find(BootCamperId);
                 _context.BootCampers.Remove(member);
                 _context.SaveChanges();
                return member;
                
                if (member == null)
                {
                    throw new UnauthorizedAccessException();
                }
                return member;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Some error happened on BootCamper Service");
                throw ex;
            }
        }

        public async Task<BootCamperDTO> PostBootCampers(BootCamperDTO member)
        {
            try
            {
                await _bootCampersRepository.PostBootCamper(member);
                return member;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<BootCampers> UpdateBootCampers(BootCamperDTO member)
        {
            try
            {
                var memberUpdated = member.Map();
                _context.BootCampers.Update(memberUpdated);
                await _context.SaveChangesAsync();
                return memberUpdated;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
