using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace ProjectApi.Entitys
{
    /// <summary>
    /// Identity用户资源
    /// </summary>
    [BsonIgnoreExtraElements]
    public class IdsIdentityResource
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
        /// 用户信息单元
        /// </summary>
        [BsonElement("claimtypes")]
        public List<string> ClaimTypes { get; set; } = new List<string>();
    }
}