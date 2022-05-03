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
    [Route("api/service")]
    public class ServiceController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IServiceRepository __ServiceRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceRepository"></param>
        public ServiceController(IServiceRepository serviceRepository)
        {
            __ServiceRepository = serviceRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("listar")]
        public ActionResult getServices()
        {
            var ret = __ServiceRepository.getServices();
            return Json(ret);
        }

    }
}
