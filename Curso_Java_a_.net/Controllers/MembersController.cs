using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Mvc;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.DTO;
using Microsoft.AspNetCore.Authorization;

namespace Curso_Java_a_.net.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class MembersController : ControllerBase
    {
        public readonly IMembersService _memberService;
        
        public ILogger<MembersController> _logger;
        
        public MembersController(IMembersService memberService, ILogger<MembersController> logger)
        {
            _memberService = memberService;
            _logger = logger;
        }


        [HttpGet]
        [Route("/GetMember")]
        public async Task<ActionResult<Members>> GetMember([FromBody] int id)
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


       [HttpPost]
        [Route("/PostMember")]
        public async Task<ActionResult<Members>> PostMembers([FromBody] MemberDTO m)
        {
            try
            {
                Members member = new Members() {
                    MembersId = 0,
                    Name = m.Name,
                    FirstName = m.Name,
                    SecondName = m.SecondName,
                    MemberRegistratior = DateTime.UtcNow,
                    CurrentLocationId=1,
                    Email = m.Email,
                    User = m.Name,
                    Password = m.Password
                };
                
                var member2 = await _memberService.PostMembers(member);               
                return Ok(member2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("/PutMember")]
        public async Task<ActionResult<Members>> UpdateMembers([FromBody] Members mem)
        {
            try
            {
                var member = await _memberService.UpdateMembers(mem);
                return Ok(member);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("/DeleteMembers")]
        public async Task<ActionResult<Members>> DeleteMembers([FromBody] MemberDTO members)
        {
            try
            {
                var member = await _memberService.DeleteMembers(members.MembersId);

                return Ok(member);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
