using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Mvc;
using Curso_Java_a_.net.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Curso_Java_a_.net.DataAccess.DTO;

namespace Curso_Java_a_.net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TechnologiesController : ControllerBase
    {
        public readonly ITechnologiesService _iTechnologiesService;        
        public ILogger<TechnologiesController> _logger;

        public TechnologiesController(ITechnologiesService ITechnologiesService, ILogger<TechnologiesController> logger)
        {
            _iTechnologiesService = ITechnologiesService;
            _logger = logger;
        }

        [HttpGet]
        [Route("/GetTechnologiesByName")]
        public async Task<ActionResult<Technologies>> GetTechnologiesByName(string Name)
        {
            try
            {
                var technologyName = await _iTechnologiesService.GetTechnologiesByNameAsync(Name);
                if (technologyName == null)
                {
                    return NoContent();
                }
                return Ok(technologyName);
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
                await _iTechnologiesService.PostTechnologiesAsync(tech);
                return Ok(tech);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpPut]
        [Route("/UpdateTechnology")]
        public async Task<ActionResult<Technologies>> UpdateTechnology([FromBody] TechnologyDTO tech)
        {
            try
            {                
                await _iTechnologiesService.UpdateTechnologiesAsync(tech);
                return Ok(tech);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpDelete]
        [Route("/DeleteTechnologyById")]
        public async Task<ActionResult<Members>> DeleteTechnologyById(int techId)
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