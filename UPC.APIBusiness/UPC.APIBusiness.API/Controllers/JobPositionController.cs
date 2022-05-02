using Microsoft.AspNetCore.Mvc;
using DBContext;
using Microsoft.AspNetCore.Authorization;
using DBEntity;

namespace UPC.APIBusiness.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/job-positions")]
    [ApiController]
    public class JobPositionController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IJobPositionRepository __JobPositionRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobPositionRepository"></param>
        public JobPositionController(IJobPositionRepository jobPositionRepository)
        {
            __JobPositionRepository = jobPositionRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("")]
        public ActionResult getJobPositions()
        {
            var ret = __JobPositionRepository.getJobPositions();
            return Json(ret);
        }

        /// <summary>
        /// <param name="code"/>
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("{code}")]
        public ActionResult getJobPosition(string code)
        {
            var ret = __JobPositionRepository.getJobPosition(code);
            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpDelete]
        [Route("{code}")]
        public ActionResult deleteJobPosition(string code)
        {
            var ret = __JobPositionRepository.deleteJobPosition(code);
            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public ActionResult createJobPosition(EntityJobPosition entity)
        {
            var ret = __JobPositionRepository.createJobPosition(entity);
            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPut]
        [Route("{code}")]
        public ActionResult updateJobPosition(string code, EntityJobPosition entity)
        {
            entity.Co_Funcion = code;
            var ret = __JobPositionRepository.updateJobPosition(entity);
            return Json(ret);
        }
    }
}
