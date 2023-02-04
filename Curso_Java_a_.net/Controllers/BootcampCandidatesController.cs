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

    public class BootcampCandidatesController : ControllerBase
    {
        readonly IBootcampCandidatesService _bootcampCandidatesService;

        internal SchoolSystemContext _context;

        public ILogger<BootcampCandidatesController> _logger;

        public BootcampCandidatesController(IBootcampCandidatesService bootcampCandidatesService, ILogger<BootcampCandidatesController>
            logger, SchoolSystemContext context)
        {
            _bootcampCandidatesService = bootcampCandidatesService;
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("/BootCamper")]
        public async Task<ActionResult<BootcampCandidates>> GetBootcampCandidate(int bootcampCandidateId)
        {
            try
            {
                var getBootcampCandidate = await _bootcampCandidatesService.GetBootcampCandidate(bootcampCandidateId);


                if (getBootcampCandidate == null)
                {
                    return BadRequest("User don´t exist");
                }
                return Ok(getBootcampCandidate);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }

        }

        [HttpGet]
        [Route("/BootCampers")]
        public async Task<ActionResult<List<BootcampCandidates>>> GetBootcampCandidates()
        {
            try
            {
                var getBootcampCandidates = await _bootcampCandidatesService.GetBootcampCandidates();


                if (getBootcampCandidates == null)
                {
                    return BadRequest("User don´t exist");
                }
                return Ok(getBootcampCandidates);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }

        }

        [HttpPost]
        [Route("/BootCamper")]
        public async Task<ActionResult<BootcampCandidates>> PostBootcampCandidate(BootcampCandidatesDTO name)
        {
            {
                try
                {
                    var postBootcampCandidate = await _bootcampCandidatesService.PostBootcampCandidate(name);
                    return Ok(postBootcampCandidate);
                }
                catch (Exception ex)
                {
                    if (ex.Message.ToLower().Contains("duplicate"))
                        return BadRequest("User already exist");
                    else
                        return Problem("Some error happened please contact Sys Admin");
                }
            }
        }
        [HttpPut]
        [Route("/BootCamper")]
        public async Task<ActionResult<BootcampCandidates>> UpdateBootcampCandidate(BootcampCandidatesDTO name)
        {
            try
            {
                var updatedBootcampCandidate = name.Map();
                await _context.BootcampCandidates.AddAsync(updatedBootcampCandidate);
                await _context.SaveChangesAsync();
                return updatedBootcampCandidate;
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpDelete]
        [Route("/BootCamper")]
        [AllowAnonymous]
        public async Task<ActionResult<BootcampCandidates>> DeleteBootcampCandidate(int bootcampCandidateId)
        {
            try
            {
                BootcampCandidates bootcampCandidate = _context.BootcampCandidates.Find(bootcampCandidateId);
                _context.BootcampCandidates.Remove(bootcampCandidate);
                _context.SaveChanges();
                return bootcampCandidate;
                if (bootcampCandidate == null)
                {
                    return BadRequest("User don´t exist");
                }
                return Ok(bootcampCandidate);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }
    }
}
