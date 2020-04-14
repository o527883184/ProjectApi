using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdentityServer4.Models;
using ProjectApi.Helpers;

namespace ProjectApi.Models
{
    public class IdsClient_Create
    {
        [Required(ErrorMessage = "客户端ID不能为空")]
        public string ClientId { get; set; }
        [Required(ErrorMessage = "客户端名称不能为空")]
        public string ClientName { get; set; }
        public ICollection<string> AllowedGrantTypes { get; set; } = GrantTypes.HybridAndClientCredentials;
        [Required(ErrorMessage = "客户端Secret不能为空")]
        public string ClientSecret { get; set; }
        [Required(ErrorMessage = "授权登录成功跳转路径不能为空")]
        [RegularExpression(RegularHelper.Uri, ErrorMessage = "授权登录成功跳转路径格式不正确")]
        public string RedirectUri { get; set; }
        [Required(ErrorMessage = "注销登录后跳转路径不能为空")]
        [RegularExpression(RegularHelper.Uri, ErrorMessage = "注销登录后跳转路径格式不正确")]
        public string PostLogoutRedirectUri { get; set; }
        [Required(ErrorMessage = "允许客户端访问的资源范围列表不能为空")]
        public List<string> AllowedScopes { get; set; } = new List<string>();
        public AccessTokenType AccessTokenType { get; set; } = AccessTokenType.Reference;
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; } = false;
        public bool AllowOfflineAccess { get; set; } = true;
        public bool RequireConsent { get; set; } = false;
    }
}