using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectApi.Entitys;
using ProjectApi.Interfaces;
using ProjectApi.Models;

namespace ProjectApi.Controllers
{
    /// <summary>
    /// Ids client info
    /// </summary>
    [Route("api/ids")]
    //[Authorize]
    [ApiController]
    public class IdsClientController : BaseController
    {
        private readonly IIdsClientBll _idsClientBll;
        /// <summary>
        /// 数据模型映射
        /// </summary>
        private readonly IMapper _mapper;

        public IdsClientController(IIdsClientBll idsClientBll, IMapper mapper)
        {
            _idsClientBll = idsClientBll;
            _mapper = mapper;
        }

        /// <summary>
        /// 新增Ids client配置信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("create", Name = nameof(CreateIdsClientAsync))]
        public async Task<IActionResult> CreateIdsClientAsync([FromBody]IdsClient_Create create)
        {
            await _idsClientBll.Create(_mapper.Map<IdsClient>(create));
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
