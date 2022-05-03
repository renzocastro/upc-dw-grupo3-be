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
using API;


namespace UPC.APIBusiness.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IEmployeeRepository __EmployeeRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeRepository"></param>
        public AuthController(IEmployeeRepository employeeRepository)
        {
            __EmployeeRepository = employeeRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pw"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public ActionResult login(AuthDataVO authData)
        {
            var ret = __EmployeeRepository.login(authData.email, authData.pw);
            return Json(ret);
        }

    }
}
