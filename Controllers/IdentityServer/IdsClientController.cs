using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Mvc;
using ProjectApi.Entitys;
using ProjectApi.Helpers;
using ProjectApi.Interfaces;
using ProjectApi.Models;

namespace ProjectApi.Controllers
{
    /// <summary>
    /// Ids client info
    /// </summary>
    [Route("api/idsclient")]
    //[Authorize]
    [ApiController]
    public class IdsClientController : BaseController
    {
        private readonly IIdsClientBll _idsClientBll;

        public IdsClientController(IIdsClientBll idsClientBll)
        {
            _idsClientBll = idsClientBll;
        }

        /// <summary>
        /// 新增Ids client配置信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("create", Name = nameof(CreateIdsClient))]
        public async Task<IActionResult> CreateIdsClient([FromBody]IdsClient_Create create)
        {
            var entity = create.MapTo<IdsClient>();
            entity.ClientSecrets = new List<Secret> { new Secret(create.ClientSecret.Sha256()) };

            await _idsClientBll.Create(entity);
            return Ok();
        }

        [HttpDelete("{id}", Name = nameof(DeleteIdsClient))]
        public async Task<IActionResult> DeleteIdsClient(string id)
        {
            await _idsClientBll.Delete(id);
            return Ok();
        }
    }
}
