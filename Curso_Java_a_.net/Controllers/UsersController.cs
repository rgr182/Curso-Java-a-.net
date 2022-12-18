using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Mvc;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.DTO;
using Microsoft.AspNetCore.Authorization;

namespace Curso_Java_a_.net.Controllers
{
    public class UsersController : ControllerBase
    {
        public readonly IMembersService _usersService;
        public ILogger<UsersController> _logger;

        public UsersController(IMembersService usersService, ILogger<UsersController> logger)
        {
            _usersService = usersService;
            _logger = logger;
        }
        [Authorize]
        [HttpGet("authenticate")]
        [Route("/user")]
        public async Task<ActionResult<Members>> GetUsers([FromBody] UserDTO user)
        {
            try
            {
                var userD = await _usersService.GetMember(user.Id);
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
    }
}
