using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ProjectApi.Extensions
{
    public static class ExceptionHandlerExtension
    {
        /// <summary>
        /// 启用全局异常处理
        /// </summary>
        /// <param name="app"></param>
        /// <param name="loggerFactory"></param>
        public static void UseExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";

                    var ex = context.Features.Get<IExceptionHandlerFeature>();
                    if (ex != null)
                    {
                        var logger = loggerFactory.CreateLogger("Project.Api.Extensions.ExceptionHandlerExtension");
                        logger.LogError(500, ex.Error, ex.Error.Message);
                    }

                    await context.Response.WriteAsync(ex?.Error?.Message ?? "An Error Occurred.");
                });
            });
        }
    }
}
