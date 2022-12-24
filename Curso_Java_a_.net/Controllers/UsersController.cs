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
        [HttpPost]
        [Route("/GetUser")]
        public async Task<ActionResult<Members>> GetUser([FromBody] UserDTO user)
        {
            try
            {
                var User = await _usersService.GetMemberByUserAndPassword(user.User,user.Password);
                if (User == null)
                {
                    return BadRequest("User don´t exist");
                }
                return Ok(User);
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }
    }
}
