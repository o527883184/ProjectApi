using System.Threading.Tasks;
using ProjectApi.Entitys;
using ProjectApi.Models;

namespace ProjectApi.Interfaces
{
    public interface IUserBll
    {
        Task<PaginatedList<User>> Get(PaginationParameters parameters);

        Task<int> Create(User user);
    }
}
