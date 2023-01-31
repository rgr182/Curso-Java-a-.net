using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Mvc;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.DTO;
using Microsoft.AspNetCore.Authorization;
using Curso_Java_a_.net.DataAccess.DTO.DTOMapping;
using Curso_Java_a_.net.DataAccess.Repository.Context;

namespace Curso_Java_a_.net.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class BootCampersController : ControllerBase
    {
        readonly IBootCampersService _memberService;
        
        internal SchoolSystemContext _context;
        
        public ILogger<BootCampersController> _logger;
        
        public BootCampersController(IBootCampersService memberService, ILogger<BootCampersController> 
            logger, SchoolSystemContext context)
        {
            _memberService = memberService;
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("/GetBootCamper")]
        public async Task<ActionResult<BootCampers>> GetBootCamper(int id)
        {
            try
            {
                var memberD = await _memberService.GetBootCamper(id);
                if (memberD == null)
                {
                    return BadRequest("User don´t exist");
                }
                return Ok(memberD);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }
        [HttpGet]
        [Route("/GetBootCampers")]
        public async Task<ActionResult<List<BootCampers>>> GetBootCampers()
        {
            try
            {
                var members = await _memberService.GetBootCampers();
                if (members == null)
                {
                    return NoContent();
                }
                return Ok(members);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpPost]
        [Route("/PostBootCamper")]
        public async Task<ActionResult<BootCampers>> PostBootCampers([FromBody] BootCamperDTO m)
        {
            try
            {               
                var member2 = await _memberService.PostBootCampers(m);               
                return Ok(member2);
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("duplicate"))
                    return BadRequest("User already exist");
                else
                    return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpPut]
        [Route("/PutBootCamper")]
        public async Task<ActionResult<BootCampers>> UpdateBootCampers([FromBody] BootCamperDTO member)
        {
            try
            {
                var memberUpdated = member.Map();
                _context.BootCampers.Update(memberUpdated);
                await _context.SaveChangesAsync();
                return memberUpdated;
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpDelete]
        [Route("/DeleteBootCamper")]
        [AllowAnonymous]
        public async Task<ActionResult<BootCampers>> DeleteBootCampers(int memberId)
        {
            try
            {
                var member = await _memberService.DeleteBootCampers(memberId);
                if (member == null)
                {
                    return BadRequest("User don´t exist");
                }
                return Ok(member);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }
    }
}
