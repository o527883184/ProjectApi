using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using ProjectApi.Data;
using ProjectApi.Entitys;
using ProjectApi.Interfaces;
using ProjectApi.Models;

namespace ProjectApi.Business
{
    public class UserBll : IUserBll
    {
        private readonly MogoContext _mogoContext;
        private readonly ILogger<UserBll> _logger;

        public UserBll(MogoContext mogoContext, ILogger<UserBll> logger)
        {
            _mogoContext = mogoContext;
            _logger = logger;
        }
        public async Task<PaginatedList<User>> Get(PaginationParameters parameters)
        {
            var data = await _mogoContext.GetCollection<User>("user").Find(t => t.Id != null).ToListAsync().ConfigureAwait(false);

            return new PaginatedList<User>(parameters.PageIndex, parameters.PageSize, 0, data);
        }
    }
}
