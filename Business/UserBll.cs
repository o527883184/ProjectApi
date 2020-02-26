using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public UserBll(MogoContext mogoContext, ILogger<UserBll> logger, IMapper mapper)
        {
            _mogoContext = mogoContext;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<PaginatedList<User_Public>> Get(PaginationParameters parameters)
        {
            var count = await _mogoContext.GetCollection<User>("user").CountDocumentsAsync(t => t.Id != null);

            var data = await _mogoContext.GetCollection<User>("user").Find(t => t.Id != null).Skip((parameters.PageNumber - 1) * parameters.PageSize).Limit(parameters.PageSize).ToListAsync().ConfigureAwait(false);

            var users = _mapper.Map<List<User>, List<User_Public>>(data);

            return new PaginatedList<User_Public>(parameters.PageNumber, parameters.PageSize, count, users);
        }
    }
}
