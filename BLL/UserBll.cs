using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
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

        public async Task<int> Create(User user)
        {
            return await _dal.CreateAsync(user);
        }

        public async Task<PaginatedList<User>> Get(PaginationParameters parameters)
        {
            if (!string.IsNullOrWhiteSpace(parameters.SortBy))
            {
                return await _dal.SearchAsync(parameters.PageNumber, parameters.PageSize, parameters.SortBy, parameters.IsAsc);
            }
            return await _dal.SearchAsync(parameters.PageNumber, parameters.PageSize);
        }

        public async Task<int> Update(User user)
        {
            return await _dal.UpdateAsync(user);
        }

        public async Task<int> Update<TField>(ObjectId id, Dictionary<string, TField> dict)
        {
            return await _dal.UpdateAsync(id, dict);
        }

        public async Task<int> Update<TField>(ObjectId id, string field, TField value)
        {
            return await _dal.UpdateAsync(id, field, value);
        }
    }
}
