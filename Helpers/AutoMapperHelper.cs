using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectApi.Helpers
{
    public static class AutoMapperHelper
    {
        private static IServiceProvider ServiceProvider;

        /// <summary>
        /// 启用automapper helper
        /// </summary>
        /// <param name="applicationBuilder"></param>
        public static void UseStateAutoMapper(this IApplicationBuilder applicationBuilder)
        {
            ServiceProvider = applicationBuilder.ApplicationServices;
        }

        //public static TDestination Map<TDestination>(object source)
        //{
        //    var mapper = ServiceProvider.GetRequiredService<IMapper>();

        //    return mapper.Map<TDestination>(source);
        //}

        //public static TDestination Map<TSource, TDestination>(TSource source)
        //{
        //    var mapper = ServiceProvider.GetRequiredService<IMapper>();

        //    return mapper.Map<TSource, TDestination>(source);
        //}

        /// <summary>
        /// 模型转换
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            var mapper = ServiceProvider.GetRequiredService<IMapper>();
            return mapper.Map<TSource, TDestination>(source);
        }

        /// <summary>
        /// 模型转换
        /// </summary>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static TDestination MapTo<TDestination>(this object source)
        {
            var mapper = ServiceProvider.GetRequiredService<IMapper>();
            return mapper.Map<TDestination>(source);
        }
    }
}
