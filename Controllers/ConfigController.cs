using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectApi.Interfaces;
using ProjectApi.Models;

namespace ProjectApi.Controllers
{
    [Route("api/config")]
    [Authorize]
    [ApiController]
    public class ConfigController : BaseController
    {
        private readonly IConfigRepository _configRepository;

        public ConfigController(IConfigRepository configRepository)
        {
            _configRepository = configRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PaginationParameters parameters)
        {
            return Ok();
        }
    }
}