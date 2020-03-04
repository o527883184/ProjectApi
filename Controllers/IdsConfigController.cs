using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using ProjectApi.Models;

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
        /// <summary>
        /// 新增Ids配置信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("create", Name = nameof(CreateIdsConfig))]
        public IActionResult CreateIdsConfig([FromBody]IdsConfig_Create create)
        {
            return Ok();
        }

        [HttpGet("{id}", Name = nameof(GetIdsConfig))]
        public IActionResult GetIdsConfig(ObjectId id)
        {
            return Ok();
        }

        /// <summary>
        /// 新增API资源
        /// </summary>
        /// <returns></returns>
        [HttpPost("apiresource/create", Name = nameof(CreateApiResource))]
        public IActionResult CreateApiResource([FromBody]IdsApiResource_Create create)
        {
            return Ok();
        }

        [HttpGet("apiresource/{id}", Name = nameof(GetApiResource))]
        public IActionResult GetApiResource(ObjectId id)
        {
            return Ok();
        }

        /// <summary>
        /// 新增Client客户端
        /// </summary>
        /// <returns></returns>
        [HttpPost("client/create", Name = nameof(CreateClient))]
        public IActionResult CreateClient([FromBody]IdsClient_Create create)
        {
            return Ok();
        }

        [HttpGet("client/{id}", Name = nameof(GetClient))]
        public IActionResult GetClient(ObjectId id)
        {
            return Ok();
        }
    }
}