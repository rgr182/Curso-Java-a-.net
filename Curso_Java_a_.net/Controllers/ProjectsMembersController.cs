using Curso_Java_a_.net.DataAccess.DTO;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
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

    public class ProjectsMembersController : ControllerBase
    {
        readonly IProjectsMembersService _ProjectsMembersService;
        public ILogger<ProjectsMembersController> _logger;
        public ProjectsMembersController(IProjectsMembersService projectsMembersService, ILogger<ProjectsMembersController>
            logger)
        {
            _ProjectsMembersService = projectsMembersService;
            _logger = logger;
        }
        [HttpGet]
        [Route("/ProjectMember")]
        public async Task<ActionResult<ProjectsMembers>> GetProjectMemberAsync(int projectMemberId)
        {
            try
            {
                ProjectsMembers projectsMembers = await _ProjectsMembersService.GetProjectMemberAsync(projectMemberId);
                if (projectsMembers == null)
                {
                    return NoContent();
                }
                return Ok(projectsMembers);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpGet]
        [Route("/ProjectsMembers")]
        public async Task<ActionResult<List<ProjectsMembers>>> GetProjectMembersAsync()
        {
            try
            {
                var projectsMembers = await _ProjectsMembersService.GetProjectMembersAsync();
                if (projectsMembers == null)
                {
                    return NoContent();
                }
                return Ok(projectsMembers);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpPost]
        [Route("/ProjectMember")]
        public async Task<ActionResult<ProjectsMembers>> PostProjectMemberAsync(ProjectsMembers projectMemberId)
        {
            {
                try
                {
                    ProjectsMembers projectsMembers = await _ProjectsMembersService.PostProjectMemberAsync(projectMemberId);
                    return Ok(projectsMembers);
                }
                catch (Exception ex)
                {
                    if (ex.Message.ToLower().Contains("duplicate"))
                        return BadRequest("ProjectMember already exist");
                    else
                        return Problem("Some error happened please contact Sys Admin");
                }
            }
        }
        [HttpPut]
        [Route("/ProjectMember")]
        public async Task<ActionResult<ProjectsMembers>> UpdateProjectMemberAsync(ProjectsMembers projectMemberId)
        {
            try
            {
                ProjectsMembers projectsMembers = await _ProjectsMembersService.UpdateProjectMemberAsync(projectMemberId);
                if (projectsMembers == null)
                {
                    return BadRequest("projects don´t exist");
                }
                return projectsMembers;
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }
        
        [HttpDelete]
        [Route("/ProjectMember")]
        [AllowAnonymous]
        public async Task<ActionResult<ProjectsMembers>> DeleteProjectMemberId(int projectMemberId)
        {
            try
            {
                ProjectsMembers projectsMembers = await _ProjectsMembersService.DeleteProjectMemberId(projectMemberId);
                if (projectsMembers == null)
                {
                    return BadRequest("projects don´t exist");
                }
                return Ok(projectsMembers);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }
    }
}
