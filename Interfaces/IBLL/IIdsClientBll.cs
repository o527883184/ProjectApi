using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectApi.Entitys;

namespace ProjectApi.Interfaces
{
    public interface IIdsClientBll
    {
        Task<int> Create(IdsClient idsClient);
        Task<int> Delete(string id);
    }
}
