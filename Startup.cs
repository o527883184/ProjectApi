using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using ProjectApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using ProjectApi.Exceptions;
using System;
using AutoMapper;
using ProjectApi.Interfaces;
using ProjectApi.DAL;
using ProjectApi.BLL;

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
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); // ���л��շ�����
                })
                .AddFluentValidation(); // ģ����֤

            // ע��automapper ����ʵ��ģ��ӳ��
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // ע��mogodb
            services.AddSingleton<MogoContext>();

            // ��http�����ض���Ϊhttps
            services.AddHttpsRedirection(option =>
            {
                option.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                option.HttpsPort = 5001;
            });

            // �������ֱ�ӷ���HTTPS���󣬽�http����ֱ��תhttps���������������ض���
            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
                options.ExcludedHosts.Add("example.com");
                options.ExcludedHosts.Add("www.example.com");
            });

            // ע�����ݲִ�
            services.AddScoped(typeof(IDal<>), typeof(Dal<>));
            services.AddScoped<IUserBll, UserBll>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseHsts();

            app.UseExceptionHandler(loggerFactory);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
