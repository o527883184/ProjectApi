using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectApi.Entitys;
using ProjectApi.Interfaces;
using ProjectApi.Models;

namespace ProjectApi.Controllers
{
    [Route("api/user")]
    //[Authorize]
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

        [HttpGet(Name = "GetUser")]
        public async Task<ActionResult<PaginatedList<User_Public>>> Get([FromQuery]PaginationParameters parameters)
        {
            var users = await _userBll.Get(parameters);

            CreateMeta(parameters, "GetUser", users);

            return Ok(users);
        }
    }
}