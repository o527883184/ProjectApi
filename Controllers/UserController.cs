using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectApi.Interfaces;
using ProjectApi.Models;

namespace ProjectApi.Controllers
{
    [Route("api/user")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBll _userBll;

        public UserController(IUserBll userBll)
        {
            _userBll = userBll;
        }

        [HttpGet(Name = "GetUser")]
        public async Task<IActionResult> Get([FromQuery]PaginationParameters parameters)
        {
            var users = await _userBll.Get(parameters);
            return Ok(users);
        }
    }
}