using System;
using System.Threading.Tasks;
using Ocelot.Configuration.File;
using Ocelot.Configuration.Repository;
using Ocelot.Responses;
using ProjectApi.Data;

namespace ProjectApi.Services
{
    /// <summary>
    /// 数据库加载路由配置信息
    /// </summary>
    public class MogoFileConfigurationRepository : IFileConfigurationRepository
    {
        private readonly MogoContext _mogoContext;

        public MogoFileConfigurationRepository(MogoContext mogoContext)
        {
            _mogoContext = mogoContext;
        }
        public Task<Response<FileConfiguration>> Get()
        {
            var file = new FileConfiguration();

            return Task.FromResult((Response<FileConfiguration>)new OkResponse<FileConfiguration>(file));
        }

        public Task<Response> Set(FileConfiguration fileConfiguration)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// CustomOcelot配置信息
    /// </summary>
    public class OcelotConfiguration
    {

    }
}
