using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using NSwag.Annotations;
using System.Net;
using System.Net.Http;
using System.Security.Claims;


namespace UPC.APIBusiness.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/project")]
    public class ProjectController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IProjectRepository __ProjectRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="projectRepository"></param>
        public ProjectController(IProjectRepository projectRepository)
        {
            __ProjectRepository = projectRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("listar")]
        public ActionResult getProjects()
        {
            var ret = __ProjectRepository.GetProjects();
            return Json(ret);
        }

        /// <summary>
        /// <paramref name="id"/>
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("obtener")]
        public ActionResult getProject(int id)
        {
            var ret = __ProjectRepository.getProject(id);
            return Json(ret);
        }

    }
}
