using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Dapper;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Curso_Java_a_.net.DataAccess.Services;
using Curso_Java_a_.net.DataAccess.Repository.Repositories.Interfaces;
using Curso_Java_a_.net.DataAccess.Repository.Repositories;

namespace Curso_Java_a_.net.Controllers
{
    public class UsersController : Controller
    {
        public readonly IUsersService _usersService;
        public readonly ILogger<UsersService> logger;
        public UsersController(IUsersService usersService, ILogger<UsersService> logger)
        {
            _usersService = usersService;
            this.logger = logger;            
        }

        [HttpGet]
        [Route("/ShowUsuarios")]
        public async Task<IHttpActionResult> GetUsers(int id)
        {
            try
            {
                var user = await _usersService.GetUserById(id);
                return (IHttpActionResult)Ok(user);
            }
            catch (Exception ex)
            {
                return (IHttpActionResult)Problem();
            }
        }
        
    }
}
