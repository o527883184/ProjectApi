using System.Threading.Tasks;
using ProjectApi.Entitys;
using ProjectApi.Interfaces;

namespace ProjectApi.BLL
{
    public class IdsApiResourceBll : IIdsApiResourceBll
    {
        private readonly IDal<IdsApiResource> _dal;

        public IdsApiResourceBll(IDal<IdsApiResource> dal)
        {
            _dal = dal;
        }

        public async Task<int> Create(IdsApiResource idsApiResource)
        {
            return await _dal.CreateAsync(idsApiResource);
        }

        public async Task<int> Delete(string id)
        {
            return await _dal.DeleteAsync(id);
        }
    }
}
