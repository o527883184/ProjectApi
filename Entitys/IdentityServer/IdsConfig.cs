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
        [BsonElement("authority")]
        public string Authority { get; set; }
        /// <summary>
        /// 客户端
        /// </summary>
        [BsonElement("clients")]
        public List<IdsClient> Clients { get; set; } = new List<IdsClient>();
        /// <summary>
        /// API资源
        /// </summary>
        [BsonElement("apiresources")]
        public List<IdsApiResource> ApiResources { get; set; } = new List<IdsApiResource>();
        /// <summary>
        /// Identity资源
        /// </summary>
        [BsonElement("identityresources")]
        public List<IdsIdentityResource> IdentityResources { get; set; } = new List<IdsIdentityResource>();
    }
}
