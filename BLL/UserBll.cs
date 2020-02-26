using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using ProjectApi.Data;
using ProjectApi.Entitys;
using ProjectApi.Interfaces;
using ProjectApi.Models;

namespace ProjectApi.BLL
{
    public class UserBll : IUserBll
    {
        private readonly ILogger<UserBll> _logger;
        private readonly IDal<User> _dal;

        public UserBll(MogoContext mogoContext, ILogger<UserBll> logger, IMapper mapper, IDal<User> dal)
        {
            _logger = logger;
            _dal = dal;
        }
        public async Task<PaginatedList<User>> Get(PaginationParameters parameters)
        {
            return await _dal.SearchAsync(parameters.PageNumber - 1, parameters.PageSize);
        }
    }
}
