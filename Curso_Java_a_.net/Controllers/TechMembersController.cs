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

    public class TechMembersController : ControllerBase
    {
        readonly ITechMembersService _TechMembersService;
        public ILogger<TechMembersController> _logger;
        public TechMembersController(ITechMembersService techMembersService, ILogger<TechMembersController>
            logger)
        {
            _TechMembersService = techMembersService;
            _logger = logger;
        }

        [HttpGet]
        [Route("/TechMember")]
        public async Task<ActionResult<TechMembers>> GetTechMemberAsync(int techMembersId)
        {
            try
            {
                TechMembers techMembers = await _TechMembersService.GetTechMemberAsync(techMembersId);
                if (techMembers == null)
                {
                    return NoContent();
                }
                return Ok(techMembers);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpGet]
        [Route("/TechMembers")]
        public async Task<ActionResult<List<TechMembers>>> GetTechMembersAsync()
        {
            try
            {
                var techMembers = await _TechMembersService.GetTechMembersAsync();
                if (techMembers == null)
                {
                    return NoContent();
                }
                return Ok(techMembers);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpPost]
        [Route("/TechMember")]
        public async Task<ActionResult<TechMembers>> PostTechMemberAsync(TechMembers techMembersId)
        {
            {
                try
                {
                    TechMembers techMembers = await _TechMembersService.PostTechMemberAsync(techMembersId);
                    return Ok(techMembers);
                }
                catch (Exception ex)
                {
                    if (ex.Message.ToLower().Contains("duplicate"))
                        return BadRequest("TechMember already exist");
                    else
                        return Problem("Some error happened please contact Sys Admin");
                }
            }
        }
        [HttpPut]
        [Route("/TechMember")]
        public async Task<ActionResult<TechMembers>> UpdateTechMemberAsync(TechMembers techMembersId)
        {
            try
            {
                TechMembers techMembers = await _TechMembersService.UpdateTechMemberAsync(techMembersId);
                if (techMembers == null)
                {
                    return BadRequest("TechMember don´t exist");
                }
                return Ok(techMembers);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }
        
        [HttpDelete]
        [Route("/TechMember")]
        [AllowAnonymous]
        public async Task<ActionResult<TechMembers>> DeleteTechMemberById(int techMembersId)
        {
            try
            {
                TechMembers techMembers = await _TechMembersService.DeleteTechMemberById(techMembersId);
                if (techMembers == null)
                {
                    return BadRequest("TechMember don´t exist");
                }
                return Ok(techMembers);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }
    }
}
