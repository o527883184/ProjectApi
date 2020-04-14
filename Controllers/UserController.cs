using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using MongoDB.Bson;
using ProjectApi.Entitys;
using ProjectApi.Interfaces;
using ProjectApi.Models;

namespace ProjectApi.Controllers
{
    [Route("api/user")]
    [Authorize]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserBll _userBll;
        /// <summary>
        /// 数据模型映射
        /// </summary>
        private readonly IMapper _mapper;

        public UserController(IUserBll userBll, IMapper mapper)
        {
            _userBll = userBll;
            _mapper = mapper;
        }

        [HttpGet(Name = nameof(Search))]
        public async Task<ActionResult<PaginatedList<User_Public>>> Search([FromQuery]PaginationParameters parameters)
        {
            await InitUserInfoAsync();
            var users = await _userBll.Get(parameters);
            CreateMeta(parameters, nameof(Search), users);
            return Ok(_mapper.Map<List<User_Public>>(users));
        }

        [HttpPut(Name = nameof(Create))]
        public async Task<ActionResult<int>> Create()
        {
            var user = new User_Public
            {
                Name = "b"
            };

            return await _userBll.Create(_mapper.Map<User>(user));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Update()
        {
            var user = new User
            {
                Name = "12345"
            };

            await _userBll.Update(user);

            await _userBll.Update(user.Id, "name", "12345abc");

            return 1;
        }
    }
}