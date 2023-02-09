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
    
    public class MemberController : ControllerBase
    {
        readonly IMembersService _memberService;
        
        internal SchoolSystemContext _context;
        
        public ILogger<MemberController> _logger;
        
        public MemberController(IMembersService memberService, ILogger<MemberController> 
            logger, SchoolSystemContext context)
        {
            _memberService = memberService;
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        [Route("/Member")]
        public async Task<ActionResult<Members>> GetMember(int id)
        {
            try
            {
                var memberD = await _memberService.GetMember(id);
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
        [Route("/Members")]
        public async Task<ActionResult<List<Members>>> GetMembers()
        {
            try
            {
                var members = await _memberService.GetMembers();
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
        [Route("/Member")]
        public async Task<ActionResult<Members>> PostMembers([FromBody] MemberDTO m)
        {
            try
            {               
                var member2 = await _memberService.PostMembers(m);               
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
        [Route("/Member")]
        public async Task<ActionResult<Members>> UpdateMembers([FromBody] MemberDTO member)
        {
            try
            {
                var memberUpdated = await _memberService.UpdateMembers(member);
                return memberUpdated;
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpDelete]
        [Route("/Member")]
        [AllowAnonymous]
        public async Task<ActionResult<Members>> DeleteMembers(int memberId)
        {
            try
            {
                var member = await _memberService.DeleteMembers(memberId);
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
