using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProjectApi.Helpers;
using ProjectApi.Interfaces;
using ProjectApi.Models;

namespace ProjectApi.Controllers
{
    /// <summary>
    /// 通用基类
    /// </summary>
    public class BaseController : ControllerBase
    {
        protected async Task<int> InitUserInfoAsync()
        {
            var token = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
            HttpClient client = new HttpClient();
            client.SetBearerToken(token);
            var content = await client.GetStringAsync("http://localhost:5000/connect/userinfo");
            return 1;
        }

        /// <summary>
        /// 返回分页相关信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="urlHelper"></param>
        /// <param name="parameters"></param>
        /// <param name="routeName"></param>
        /// <param name="paginatedList"></param>
        protected void CreateMeta<T>(PaginationParameters parameters, string routeName, PaginatedList<T> paginatedList) where T : class
        {
            var meta = new
            {
                paginatedList.PaginationParameters.PageSize,
                paginatedList.PaginationParameters.PageNumber,
                paginatedList.PageCount,
                paginatedList.TotalCount,
                PrePageLink = paginatedList.HasPre ? CreateUri(parameters, PaginationUriType.PrePage, routeName) : string.Empty,
                NextPageLink = paginatedList.HasNext ? CreateUri(parameters, PaginationUriType.NextPage, routeName) : string.Empty
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(meta, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver() // 驼峰命名
            }));
        }

        /// <summary>
        /// 生成分页前后页URI
        /// </summary>
        /// <param name="urlHelper"></param>
        /// <param name="parameters"></param>
        /// <param name="type"></param>
        /// <param name="routeName"></param>
        /// <returns></returns>
        private string CreateUri(PaginationParameters parameters, PaginationUriType type, string routeName)
        {
            switch (type)
            {
                case PaginationUriType.PrePage:
                    var preParameters = new
                    {
                        PageNumber = parameters.PageNumber - 1,
                        parameters.PageSize,
                        SortBy = string.IsNullOrWhiteSpace(parameters.SortBy) || string.Equals(parameters.SortBy, nameof(IEntity.Id)) ? string.Empty : (parameters.IsAsc ? parameters.SortBy : $"-{parameters.SortBy}")
                    };
                    return Url.Link(routeName, preParameters);

                case PaginationUriType.NextPage:
                    var nextParameters = new
                    {
                        PageNumber = parameters.PageNumber + 1,
                        parameters.PageSize,
                        SortBy = string.IsNullOrWhiteSpace(parameters.SortBy) || string.Equals(parameters.SortBy, nameof(IEntity.Id)) ? string.Empty : (parameters.IsAsc ? parameters.SortBy : $"-{parameters.SortBy}")
                    };
                    return Url.Link(routeName, nextParameters);

                default:
                    return null;
            }
        }

        /// <summary>
        /// 自定义模型验证错误格式
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public override UnprocessableEntityObjectResult UnprocessableEntity([ActionResultObjectValue] ModelStateDictionary modelState)
        {
            if (modelState == null)
                throw new ArgumentNullException(nameof(modelState));

            return base.UnprocessableEntity(new ResourceValidationHelper(modelState));
        }
    }

    public enum PaginationUriType
    {
        /// <summary>
        /// 上一页
        /// </summary>
        PrePage,
        /// <summary>
        /// 下一页
        /// </summary>
        NextPage
    }
}
