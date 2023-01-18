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
        [Route("/GetTechName")]
        public async Task<ActionResult<Technologies>> GetTechnologiesByName(string Name)
        {
            try
            {
                var technologyName = _iTechnologiesService.GetTechnologiesByName(Name);
                if (technologyName == null)
                {
                    return BadRequest("Technology don´t exist");
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
        public async Task<ActionResult<Members>> PostMembers([FromBody] TechnologyDTO tech)
        {
            try
            {
                var postTech = _iTechnologiesService;
                await _iTechnologiesService.PostTechnologiesAsync(tech);
                return Ok(tech);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}