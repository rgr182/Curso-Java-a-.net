using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Services;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Curso_Java_a_.net.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class BootcampsController : ControllerBase
    {
        readonly IBootcampsService _bootcampsService;

        internal SchoolSystemContext _context;

        public ILogger<BootcampsController> _logger;

        public BootcampsController(IBootcampsService bootcampsService, ILogger<BootcampsController>
            logger, SchoolSystemContext context)
        {
            _bootcampsService = bootcampsService;
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("/BootCamp")]
        public async Task<ActionResult<Bootcamps>> GetBootcamps(int bootcampId)
        {
            try
            {
                var getBootcamp = await _bootcampsService.GetBootcamps(bootcampId);


                if (getBootcamp == null)
                {
                    return BadRequest("Bootcamp don´t exist");
                }
                return Ok(getBootcamp);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }

        }

        [HttpGet]
        [Route("/BootCamps")]
        public async Task<ActionResult<List<Bootcamps>>> GetBootcamps()
        {
            try
            {
                var getBootcamps = await _bootcampsService.GetBootcamps();


                if (getBootcamps == null)
                {
                    return BadRequest("Bootcamps don´t exist");
                }
                return Ok(getBootcamps);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }

        }

        [HttpPost]
        [Route("/BootCamp")]
        public async Task<ActionResult<Bootcamps>> PostBootcamps(BootcampsDTO name)
        {
            {
                try
                {
                    var postBootcamp = await _bootcampsService.PostBootcamps(name);
                    return Ok(postBootcamp);
                }
                catch (Exception ex)
                {
                    if (ex.Message.ToLower().Contains("duplicate"))
                        return BadRequest("Bootcamps already exist");
                    else
                        return Problem("Some error happened please contact Sys Admin");
                }
            }
        }
        [HttpPut]
        [Route("/BootCamp")]
        public async Task<ActionResult<Bootcamps>> UpdateBootcamps(BootcampsDTO name)
        {
            try
            {
                var updatedBootcamp = name.Map();
                await _context.Bootcamps.AddAsync(updatedBootcamp);
                await _context.SaveChangesAsync();
                return updatedBootcamp;
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpDelete]
        [Route("/BootCamp")]
        [AllowAnonymous]
        public async Task<ActionResult<Bootcamps>> DeleteBootcamps(int bootcampId)
        {
            try
            {
                Bootcamps bootcamp = _context.Bootcamps.Find(bootcampId);
                _context.Bootcamps.Remove(bootcamp);
                _context.SaveChanges();
                return bootcamp;
                if (bootcamp == null)
                {
                    return BadRequest("Bootcamps don´t exist");
                }
                return Ok(bootcamp);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }
    }
}
