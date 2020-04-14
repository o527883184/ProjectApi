using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using ProjectApi.Entitys;
using ProjectApi.Models;

namespace ProjectApi.Interfaces
{
    public interface IUserBll
    {
        Task<PaginatedList<User>> Get(PaginationParameters parameters);

        Task<int> Create(User user);

        Task<int> Update(User user);

        Task<int> Update<TField>(string id, string field, TField value);

        Task<int> Update<TField>(string id, Dictionary<string, TField> dict);
    }
}
