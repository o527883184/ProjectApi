using System.Threading.Tasks;
using ProjectApi.Entitys;

namespace ProjectApi.Interfaces
{
    public interface IIdsApiResourceBll
    {
        Task<int> Create(IdsApiResource idsApiResource);
        Task<int> Delete(string id);
    }
}
