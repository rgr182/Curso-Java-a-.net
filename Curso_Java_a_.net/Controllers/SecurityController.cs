using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using Microsoft.AspNetCore.Mvc;
using Curso_Java_a_.net.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Curso_Java_a_.net.DataAccess.DTO;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;

namespace Curso_Java_a_.net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        public readonly ISessionService _sessionService;
        public readonly IUsersService _usersService;
        public ILogger<SecurityController> _logger;

        public SecurityController(ISessionService securityService,
                                  ILogger<SecurityController> logger,
                                  IUsersService usersService)
        {
            _sessionService = securityService;
            _logger = logger;
            _usersService = usersService;
        }

        [HttpGet]
        [Route("/Auth")]
        public async Task<ActionResult<Session>> Auth()
        {
            try
            {
                var r = ((ClaimsIdentity)User.Identity).FindFirst("Id");
                var session = await _sessionService.GetSession(int.Parse(r.Value));

                return Ok(session);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("User and password does not match");
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpPost]
        [Route("/api/login")]
        [AllowAnonymous]
        public async Task<ActionResult<Session>> Login([FromBody] UserDTO user)
        {
            try
            {
                var userD = await _usersService.LoginUser(user.User, user.Password);
                var session = await _sessionService.SaveSession(userD);                

                return Ok(session);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("User and password does not match");
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }
    }
}
