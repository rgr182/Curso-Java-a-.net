using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Mvc;
using Curso_Java_a_.net.DataAccess.Entities;


namespace Curso_Java_a_.net.Controllers
{
    public class UsersController : ControllerBase
    {
        public readonly IUsersService _usersService;
        public ILogger<UsersController> _logger;

        public UsersController(IUsersService usersService, ILogger<UsersController> logger)
        {
            _usersService = usersService;
            _logger = logger;
        }

        [HttpGet]
        [Route("/ShowUsuarios")]

        
        public async Task<ActionResult<Users>> GetUsers(string usuario, string pass)
        {
            try
            {
                var user = await _usersService.GetUserByUserAndPassword(usuario, pass);

                string token = Guid.NewGuid().ToString();
                DateTime issuedOn = DateTime.Now;
                DateTime expiredOn = DateTime.Now.AddDays(1);
                return Ok(token);
            }
            catch (UnauthorizedAccessException uex) {
                _logger.LogError(uex, "User and password does not match");
                return Unauthorized("User and password does not match");
            }
            catch (Exception)
            {
                
                return Problem("Some error happened please contact Sys Admin");
            }
        }
        [HttpPost]
        [Route("/Login")]
        public async Task<ActionResult<string>> Login(string user, string password)
        {
            try
            {
                var auth = await _usersService.LoginUser(user, password);
                if (auth == "")
                {
                     return Unauthorized("Usuario o contraseña incorrectos");
                }
                return Ok(auth);
            }
            catch (Exception ex)
            {
                return Problem(ex.ToString());
            }
        }

    }


}
