using System.Threading.Tasks;
using MongoDB.Driver;
using ProjectApi.Entitys;
using ProjectApi.Interfaces;
using ProjectApi.Models;

namespace ProjectApi.BLL
{
    public class UserBll : IUserBll
    {
        private readonly IDal<User> _dal;

        public UserBll(IDal<User> dal)
        {
            _dal = dal;
        }
        public async Task<PaginatedList<User>> Get(PaginationParameters parameters)
        {
            if (!string.IsNullOrWhiteSpace(parameters.SortBy))
            {
                return await _dal.SearchAsync(parameters.PageNumber, parameters.PageSize, parameters.SortBy, false);
            }
            return await _dal.SearchAsync(parameters.PageNumber, parameters.PageSize);
        }
    }
}
