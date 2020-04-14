using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using ProjectApi.Entitys;
using ProjectApi.Interfaces;

namespace ProjectApi.BLL
{
    public class IdsClientBll : IIdsClientBll
    {
        private readonly IDal<IdsClient> _dal;

        public IdsClientBll(IDal<IdsClient> dal)
        {
            _dal = dal;
        }

        public async Task<int> Create(IdsClient idsClient)
        {
            return await _dal.CreateAsync(idsClient);
        }

        public async Task<int> Delete(string id)
        {
            return await _dal.DeleteAsync(id);
        }
    }
}
