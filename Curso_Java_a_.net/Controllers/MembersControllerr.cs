using Curso_Java_a_.net.DataAccess.Services.Interfaces;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using Microsoft.AspNetCore.Mvc;
using Curso_Java_a_.net.DataAccess.Entities;
using Curso_Java_a_.net.DataAccess.DTO;
using Microsoft.AspNetCore.Authorization;
using System.Web.Http;
using Curso_Java_a_.net.DataAccess.Services;
using Curso_Java_a_.net.DataAccess.Repository.Repositories;
using Curso_Java_a_.net.DataAccess.Repository.Context;
using Curso_Java_a_.net.DataAccess.Entities.Mapping;

namespace Curso_Java_a_.net.Controllers
{
    public class MembersController : ControllerBase
    {
        private UsersSubjectsMapping usersSubjectsMapping;
        private SubjectsMapping subjectsMapping;
        private readonly AppService appService = 
            new AppService(new AppRepository(SchoolSystemContext.Create()));










    }

}
