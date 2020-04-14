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
    [Route("api/idsapiresource")]
    public class IdsApiResourceController : BaseController
    {
        private readonly IIdsApiResourceBll _idsApiResourceBll;

        public IdsApiResourceController(IIdsApiResourceBll idsApiResourceBll)
        {
            _idsApiResourceBll = idsApiResourceBll;
        }

        [HttpPost("create", Name = nameof(CreateIdsApiResource))]
        public async Task<IActionResult> CreateIdsApiResource([FromBody]IdsApiResource_Create create)
        {
            var entity = create.MapTo<IdsApiResource>();
            entity.ApiSecrets = new List<Secret> { new Secret(create.ApiSecret.Sha256()) };
            int result = await _idsApiResourceBll.Create(entity);
            return Ok();
        }

        [HttpDelete("{id}", Name = nameof(DeleteIdsApiResource))]
        public async Task<IActionResult> DeleteIdsApiResource(string id)
        {
            int result = await _idsApiResourceBll.Delete(id);
            return Ok();
        }
    }
}
