using System.Collections.Generic;
using IdentityServer4.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectApi.Entitys
{
    /// <summary>
    /// IdentityService 配置信息
    /// </summary>
    [BsonIgnoreExtraElements]
    public class IdsConfig : Entity
    {
        /// <summary>
        /// 授权Uri
        /// </summary>
        public string Authority { get; set; }

        /// <summary>
        /// 客户端
        /// </summary>
        public List<IdsClient> Clients { get; set; }
        /// <summary>
        /// API资源
        /// </summary>
        public List<IdsApiResource> ApiResources { get; set; }
        /// <summary>
        /// Identity资源
        /// </summary>
        public List<IdsIdentityResource> IdentityResources { get; set; }
    }
}
