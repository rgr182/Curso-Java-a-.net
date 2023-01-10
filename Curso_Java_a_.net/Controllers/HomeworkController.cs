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
    public class HomeworkController : ControllerBase
    {
        public ILogger<HomeworkController> _logger;
        public readonly IHomeworkService _homeworkService;
        public HomeworkController(IHomeworkService homeworkService, ILogger<HomeworkController> logger)
        {
            _homeworkService = homeworkService;
            _logger = logger;
        }
        
        [HttpGet]
        [Route("/tareas")]
        public async Task<ActionResult> GetHomeworks(long UserId, int Role, long GroupId, bool isActive, string OrderDate, string Status)
        {
            try
            {
                var result = await _homeworkService.GetHomeworks(UserId, Role, GroupId, isActive, OrderDate, Status);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las tareas");
                return BadRequest(ex.Message);
            }
        }
    }
}
