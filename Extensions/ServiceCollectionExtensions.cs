using Microsoft.Extensions.DependencyInjection;
using ProjectApi.BLL;
using ProjectApi.DAL;
using ProjectApi.Interfaces;

namespace ProjectApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 注入业务仓储
        /// </summary>
        /// <param name="services"></param>
        public static void AddBLL(this IServiceCollection services)
        {
            services.AddScoped<IUserBll, UserBll>();
            services.AddScoped<IIdsClientBll, IdsClientBll>();
        }

        /// <summary>
        /// 注入数据仓储
        /// </summary>
        /// <param name="services"></param>
        public static void AddDAL(this IServiceCollection services)
        {
            services.AddScoped(typeof(IDal<>), typeof(Dal<>));
        }
    }
}
