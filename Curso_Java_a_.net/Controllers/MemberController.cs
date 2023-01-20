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
        [Route("/GetMember")]
        public async Task<ActionResult<Member>> GetMember([FromBody] int id)
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
        [Route("/GetMember")]
        public async Task<ActionResult<List<Member>>> GetMembers()
        {
            try
            {
                var members = await _memberService.GetMembers();
                return Ok(members);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpPost]
        [Route("/PostMember")]
        public async Task<ActionResult<Member>> PostMembers([FromBody] MemberDTO m)
        {
            try
            {               
                var member2 = await _memberService.PostMembers(m);               
                return Ok(member2);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpPut]
        [Route("/PutMember")]
        public async Task<ActionResult<Member>> UpdateMembers(int memberId,[FromBody] MemberDTO member)
        {
            try
            {
                var memberUpdated = member.Map();
                _context.Member.Update(memberUpdated);
                await _context.SaveChangesAsync();
                return memberUpdated;
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpDelete]
        [Route("/DeleteMember")]
        [AllowAnonymous]
        public async Task<ActionResult<Member>> DeleteMembers(int memberId)
        {
            try
            {
                var member = await _memberService.DeleteMembers(memberId);
                return Ok(member);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }
    }
}
