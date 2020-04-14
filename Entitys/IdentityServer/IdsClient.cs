using System.Collections.Generic;
using IdentityServer4.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectApi.Entitys
{
    /// <summary>
    /// IdsClient配置
    /// </summary>
    [BsonIgnoreExtraElements]
    public class IdsClient : Entity
    {
        /// <summary>
        /// 唯一的客户端ID
        /// </summary>
        [BsonElement("clientid")]
        public string ClientId { get; set; }
        /// <summary>
        /// 客户端名称
        /// </summary>
        [BsonElement("clientname")]
        public string ClientName { get; set; }
        /// <summary>
        /// 客户端密钥
        /// </summary>
        [BsonElement("clientsecrets")]
        public ICollection<Secret> ClientSecrets { get; set; }
        /// <summary>
        /// 允许客户端访问的资源范围列表
        /// </summary>
        [BsonElement("allowedscopes")]
        public List<string> AllowedScopes { get; set; } = new List<string>();

        #region << Ids中Client配置信息 >>

        /// <summary>
        /// 客户端URI
        /// </summary>
        [BsonElement("clienturi")]
        public string ClientUri { get; set; }
        /// <summary>
        /// 授权类型
        /// </summary>
        [BsonElement("allowedgranttypes")]
        public GrantTypes AllowedGrantTypes { get; set; }
        /// <summary>
        /// 允许离线令牌(用于启用刷新令牌)
        /// </summary>
        [BsonElement("allowofflineaccess")]
        public bool AllowOfflineAccess { get; set; }
        /// <summary>
        /// 令牌类型
        /// </summary>
        [BsonElement("accesstokentype")]
        public AccessTokenType AccessTokenType { get; set; }
        /// <summary>
        /// 令牌失效时间(默认1800秒)
        /// </summary>
        [BsonElement("accesstokenlifetime")]
        public int AccessTokenLifetime { get; set; } = 1800;
        /// <summary>
        /// 始终在令牌中包含用户信息单元(token中包含用户信息)
        /// </summary>
        [BsonElement("alwaysincludeuserclaimsinidtoken")]
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; } = false;
        /// <summary>
        /// 启用授权同意界面
        /// </summary>
        [BsonElement("requireconsent")]
        public bool RequireConsent { get; set; } = false;
        /// <summary>
        /// 授权登录成功跳转(身份或访问令牌发送到的网络位置)
        /// </summary>
        [BsonElement("redirecturis")]
        public List<string> RedirectUris { get; set; }
        /// <summary>
        /// 注销登录后跳转URI
        /// </summary>
        [BsonElement("postlogoutredirecturis")]
        public List<string> PostLogoutRedirectUris { get; set; } = new List<string>();
        /// <summary>
        /// 注销登录前跳转URI
        /// </summary>
        [BsonElement("frontchannellogouturi")]
        public List<string> FrontChannelLogoutUri { get; set; } = new List<string>();

        #endregion

        #region << Client中配置信息 >>

        /// <summary>
        /// 登录认证方式(默认为Cookie)
        ///// </summary>
        //[BsonElement("signinscheme")]
        //public string SignInScheme { get; set; } = CookieAuthenticationDefaults.AuthenticationScheme;
        /// <summary>
        /// 请求认证URI(认证服务器地址)
        /// </summary>
        //[BsonElement("authority")]
        //public string Authority { get; set; }
        //[BsonElement("savetokens")]
        //public bool SaveTokens { get; set; } = true;
        //[BsonElement("getclaimsfromuserinfoendpoint")]
        //public bool GetClaimsFromUserInfoEndpoint { get; set; } = true;
        //[BsonElement("requirehttpsmetadata")]
        //public bool RequireHttpsMetadata { get; set; } = false;
        /// <summary>
        /// 访问资源(Identity 及 API资源)
        ///// </summary>
        //[BsonElement("scope")]
        //public List<string> Scope { get; set; } = new List<string>();
        /// <summary>
        /// 不映射到User Claims里的属性
        ///// </summary>
        //[BsonElement("deleteclaim")]
        //public List<string> DeleteClaim { get; set; } = new List<string>();
        ///// <summary>
        ///// 从过滤集合中移出的属性(映射到User Claims里的属性)
        ///// </summary>
        //[BsonElement("removeclaim")]
        //public List<string> RemoveClaim { get; set; } = new List<string>();

        #endregion

        [BsonElement("isdelete")]
        public bool IsDelete { get; set; } = false;
    }
}
