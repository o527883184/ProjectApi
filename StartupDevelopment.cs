using System;
using AutoMapper;
using FluentValidation.AspNetCore;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using ProjectApi.BLL;
using ProjectApi.Data;
using ProjectApi.Exceptions;
using ProjectApi.Interfaces;

namespace ProjectApi
{
    public class StartupDevelopment
    {
        public StartupDevelopment(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); // 序列化驼峰命名
                })// .ConfigureApiBehaviorOptions()
                .AddFluentValidation(); // 模型验证

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:5000";
                    options.ApiName = "projectapi";
                    options.RequireHttpsMetadata = false;
                    options.ApiSecret = "projectapisecret";
                });

            // 注入automapper 数据实体模型映射
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // 注入mogodb
            services.AddSingleton<MogoContext>();

            // 将http请求重定向为https
            services.AddHttpsRedirection(option =>
            {
                option.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                option.HttpsPort = 5002;
            });

            //services.AddAuthorization();

            // 注入数据仓储
            services.AddScoped<IUserBll, UserBll>();

            // 生成URI
            //services.AddScoped<IUrlHelper>(factory =>
            //{
            //    var actionContext = factory.GetService<IActionContextAccessor>().ActionContext;
            //    return new UrlHelper(actionContext);
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(loggerFactory);

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
