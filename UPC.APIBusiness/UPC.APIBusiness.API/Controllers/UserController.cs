using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UPC.Business.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {

        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IUserRepository _UserRepository;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserRepository"></param>
        public UserController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;

        }

        /// <summary>
        /// GetListUser
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [SwaggerOperation("GetListUser")]
        [AllowAnonymous]
        [HttpGet]
        [Route("GetListUser")]
        public ActionResult Get()
        {
            var ret = _UserRepository.GetUsers();
            //var ret = new List<EntityUser>();

            //var user1 = new EntityUser();
            //user1.Nombres = "Freddy";
            //user1.Apellidos = "Quispe";
            //user1.Correo = "fquispe@gmail.com";
            //ret.Add(user1);

            //var user2 = new EntityUser();
            //user2.Nombres = "Juan";
            //user2.Apellidos = "Perez";
            //user2.Correo = "jperez@gmail.com";
            //ret.Add(user2);

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }
    }
}