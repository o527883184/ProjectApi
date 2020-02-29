using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectApi.Controllers
{
    /// <summary>
    /// IdentityService 配置
    /// </summary>
    [Route("api/idsconfig")]
    [Authorize]
    [ApiController]
    public class IdsConfigController : BaseController
    {
        [HttpGet]
        public IActionResult Create()
        {
            return Ok();
        }
    }
}