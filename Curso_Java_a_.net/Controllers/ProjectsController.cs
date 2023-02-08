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
        [Route("/Projects")]
        public async Task<ActionResult<Projects>> GetProject(int projectId)
        {
            try
            {
                var getProject = await _ProjectsService.GetProject(projectId);
                if (getProject == null)
                {
                    return BadRequest("Bootcamp don´t exist");
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
        [Route("/Projects")]
        public async Task<ActionResult<Projects>> PostProject(ProjectsDTO name)
        {
            {
                try
                {
                    var postProjects = await _ProjectsService.PostProject(name);
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
        [Route("/Projects")]
        public async Task<ActionResult<Projects>> UpdateProject(ProjectsDTO name)
        {
            try
            {
                Projects updateProject = name.Map();
                await _context.Projects.AddAsync(updateProject);
                await _context.SaveChangesAsync();
                return updateProject;
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpDelete]
        [Route("/Projects")]
        [AllowAnonymous]
        public async Task<ActionResult<Projects>> DeleteProject(int projectId)
        {
            try
            {
                Projects projects = _context.Projects.Find(projectId);
                _context.Projects.Remove(projects);
                _context.SaveChanges();
                return projects;
                if (projects == null)
                {
                    return BadRequest("projects don´t exist");
                }
                return Ok(projects);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }
    }
}
