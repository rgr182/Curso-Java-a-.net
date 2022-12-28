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
    
    public class UsersController : ControllerBase
    {
        public readonly IMembersService _usersService;
        
        public ILogger<UsersController> _logger;
        
        public UsersController(IMembersService usersService, ILogger<UsersController> logger)
        {
            _usersService = usersService;
            _logger = logger;
        }


        [HttpGet]
        [Route("/GetUser")]
        public async Task<ActionResult<Members>> GetMember([FromBody] int id)
        {
            try
            {
                var userD = await _usersService.GetMember(id);
                if (userD == null)
                {
                    return BadRequest("User don´t exist");
                }
                return Ok(userD);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }


       [HttpPost]
        [Route("/PostUser")]
        public async Task<ActionResult<Members>> PostMembers([FromBody] Members m)
        {
            try
            {
                var member = await _usersService.PostMembers(m);
               
                return Ok(member);

            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPut]
        [Route("/PutUser")]
        public async Task<ActionResult<Members>> UpdateMembers([FromBody] Members mem)
        {
            try
            {
                var member = await _usersService.UpdateMembers(mem);

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
                var member = await _usersService.DeleteMembers(members.MembersId);

                return Ok(member);

            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
