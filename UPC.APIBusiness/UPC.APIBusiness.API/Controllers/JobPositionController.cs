using Microsoft.AspNetCore.Mvc;
using DBContext;
using Microsoft.AspNetCore.Authorization;

namespace UPC.APIBusiness.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/job-position")]
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
        /// <paramref name="code"/>
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
    }
}
