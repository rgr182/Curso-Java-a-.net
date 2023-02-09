using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Services;
using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Curso_Java_a_.net.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class ProjectsController : ControllerBase
    {
        readonly IProjectsService _ProjectsService;

        internal SchoolSystemContext _context;

        public ILogger<ProjectsController> _logger;
        public ProjectsController(IProjectsService projectsService, ILogger<ProjectsController>
            logger, SchoolSystemContext context)
        {
            _ProjectsService = projectsService;
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("/Project")]
        public async Task<ActionResult<Projects>> GetProject(int projectId)
        {
            try
            {
                var getProject = await _ProjectsService.GetProject(projectId);
                if (getProject == null)
                {
                    return NoContent();
                }
                return Ok(getProject);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpGet]
        [Route("/Projects")]
        public async Task<ActionResult<List<Projects>>> GetProjects()
        {
            try
            {
                var getProjects = await _ProjectsService.GetProjects();
                if (getProjects == null)
                {
                    return BadRequest("Bootcamps don´t exist");
                }
                return Ok(getProjects);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpPost]
        [Route("/Project")]
        public async Task<ActionResult<Projects>> PostProject(ProjectsDTO project)
        {
            {
                try
                {
                    var postProjects = await _ProjectsService.PostProject(project);
                    return Ok(postProjects);
                }
                catch (Exception ex)
                {
                    if (ex.Message.ToLower().Contains("duplicate"))
                        return BadRequest("Project already exist");
                    else
                        return Problem("Some error happened please contact Sys Admin");
                }
            }
        }
        [HttpPut]
        [Route("/Project")]
        public async Task<ActionResult<Projects>> UpdateProject(ProjectsDTO project)
        {
            try
            {
                var projectUpdated = await _ProjectsService.UpdateProject(project);
                return projectUpdated;
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }
        
        [HttpDelete]
        [Route("/Project")]
        [AllowAnonymous]
        public async Task<ActionResult<Projects>> DeleteProject(int projectId)
        {
            try
            {
                var projectDeleted = await _ProjectsService.DeleteProject(projectId);
                if (projectDeleted == null)
                {
                    return BadRequest("projects don´t exist");
                }
                return Ok(projectDeleted);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }
    }
}
