using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Mvc;
using Curso_Java_a_.net.DataAccess.Entities;

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

        [HttpGet]
        [Route("/ShowUsuarios")]        
        public async Task<ActionResult<Members>> GetUsers(string usuario, string pass)
        {
            try
            {
                var user = await _usersService.GetMemberByUserAndPassword(usuario, pass);            
                return Ok(user);
            }
            catch (UnauthorizedAccessException) {                
                return Unauthorized("User and password does not match");
            }
            catch (Exception)
            {                
                return Problem("Some error happened please contact Sys Admin");
            }
        }
    }
}