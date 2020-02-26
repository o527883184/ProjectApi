using System.Threading.Tasks;
using ProjectApi.Models;

namespace ProjectApi.Interfaces
{
    public interface IUserBll
    {
        Task<PaginatedList<User_Public>> Get(PaginationParameters parameters);
    }
}
