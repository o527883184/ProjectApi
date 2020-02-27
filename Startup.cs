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
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); // ���л��շ�����
                })
                .AddFluentValidation(); // ģ����֤

            // �����֤����
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:5000";
                    options.ApiName = "projectapi";
                    options.RequireHttpsMetadata = false;
                    options.ApiSecret = "projectapisecret";
                });

            // ע��automapper ����ʵ��ģ��ӳ��
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // ע��mogodb
            services.AddSingleton<MogoContext>();

            // ��http�����ض���Ϊhttps
            services.AddHttpsRedirection(option =>
            {
                option.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                option.HttpsPort = 5002;
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

            // ע��ִ�
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

            app.UseAuthentication(); // ��֤

            app.UseAuthorization(); // ��Ȩ

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
