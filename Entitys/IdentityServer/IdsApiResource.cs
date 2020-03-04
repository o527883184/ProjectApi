using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectApi.Entitys
{
    /// <summary>
    /// API资源
    /// </summary>
    [BsonIgnoreExtraElements]
    public class IdsApiResource
    {
        /// <summary>
        /// 名称
        /// </summary>
        [BsonElement("name")]
        public string Name { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        [BsonElement("displayname")]
        public string DisplayName { get; set; }
        /// <summary>
        /// 密钥
        /// </summary>
        [BsonElement("apisecret")]
        public string ApiSecret { get; set; }
        /// <summary>
        /// 令牌添加identity用户信息单元信息
        /// </summary>
        [BsonElement("userclaims")]
        public List<string> UserClaims { get; set; } = new List<string>();
        /// <summary>
        /// 可访问资源
        /// </summary>
        [BsonElement("scopes")]
        public List<Scope> Scopes { get; set; } = new List<Scope>();
    }

    [BsonIgnoreExtraElements]
    public class Scope
    {
        /// <summary>
        /// 名称
        /// </summary>
        [BsonElement("name")]
        public string Name { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        [BsonElement("displayname")]
        public string DisplayName { get; set; }
        /// <summary>
        /// API信息单元
        /// </summary>
        [BsonElement("claimtypes")]
        public List<string> ClaimTypes { get; set; } = new List<string>();
    }
}