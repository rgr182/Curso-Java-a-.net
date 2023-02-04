using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Mvc;
using Curso_Java_a_.net.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using System.Data.Entity;
using System.Diagnostics.Metrics;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;

namespace Curso_Java_a_.net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TechnologiesController : ControllerBase
    {
        public readonly ITechnologiesService _iTechnologiesService;        
        public ILogger<TechnologiesController> _logger;
        internal SchoolSystemContext _context;

        public TechnologiesController(ITechnologiesService ITechnologiesService, ILogger<TechnologiesController> logger, SchoolSystemContext context)
        {
            _iTechnologiesService = ITechnologiesService;
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("/GetTechnology")]
        public async Task<ActionResult<Technologies>> GetTechnologyAsync(int technologyId)
        {
            try
            {
                var technology = await _iTechnologiesService.GetTechnologyAsync(technologyId);
                if (technology == null)
                {
                    return NoContent();
                }
                return Ok(technology);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpGet]
        [Route("/GetTechnologies")]
        public async Task<ActionResult<List<Technologies>>> GetTechnologiesAsync()
        {
            try
            {
                var tech = await _context.Technologies.ToListAsync();

                if (tech == null)
                {
                    return NoContent();
                }
                return Ok(tech);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }



        [HttpPost]
        [Route("/PostTechnology")]
        public async Task<ActionResult<Members>> PostTechnology([FromBody] TechnologyDTO tech)
        {
            try
            {                
                var postTech =  await _iTechnologiesService.PostTechnologiesAsync(tech);
                return Ok(postTech);
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("duplicate"))
                    return BadRequest("Technology already exist");
                else
                    return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpPut]
        [Route("/UpdateTechnology")]
        public async Task<ActionResult<Technologies>> UpdateTechnologiesAsync([FromBody] TechnologyDTO tech)
        {
            try
            {                
                var techUpdate = tech.Map();
                _context.Technologies.Update(techUpdate);
                await _context.SaveChangesAsync();
                return techUpdate;
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpDelete]
        [Route("/DeleteTechnologyById")]
        public async Task<ActionResult<Technologies>> DeleteTechnologyById(int techId)
        {
            try
            {
                await _iTechnologiesService.DeleteTechnologiesById(techId);
               
                return Ok();
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }
    }
}