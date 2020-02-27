using System;
using AutoMapper;
using FluentValidation.AspNetCore;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using ProjectApi.Data;
using ProjectApi.Extensions;

namespace ProjectApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
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
                })
                .AddFluentValidation(); // 模型验证

            // 添加认证服务
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

            // 让浏览器直接发起HTTPS请求，将http请求直接转https，跳过服务器端重定向
            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
                options.ExcludedHosts.Add("example.com");
                options.ExcludedHosts.Add("www.example.com");
            });

            // 注入仓储
            services.AddBLL();
            services.AddDAL();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseHsts();

            app.UseExceptionHandler(loggerFactory);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication(); // 认证

            app.UseAuthorization(); // 授权

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
