using System.Collections.Generic;

namespace ProjectApi.Models
{
    //public class IdsApiResource
    //{
        //    /// <summary>
        //    /// 名称
        //    /// </summary>
        //    public string Name { get; set; }
        //    /// <summary>
        //    /// 显示名称
        //    /// </summary>
        //    public string DisplayName { get; set; }
        //    /// <summary>
        //    /// 密钥
        //    /// </summary>
        //    public string ApiSecret { get; set; }
        //    /// <summary>
        //    /// 令牌添加identity用户信息单元信息
        //    /// </summary>
        //    public List<string> UserClaims { get; set; } = new List<string>();
        //    /// <summary>
        //    /// API资源可访问单元
        //    /// </summary>
        //    public List<string> ClaimTypes { get; set; } = new List<string>();
    //}

    public class IdsApiResource_Create
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 密钥
        /// </summary>
        public string ApiSecret { get; set; }
        /// <summary>
        /// 令牌添加identity用户信息单元信息
        /// </summary>
        public List<string> UserClaims { get; set; } = new List<string>();
        /// <summary>
        /// API资源可访问单元
        /// </summary>
        public List<string> ClaimTypes { get; set; } = new List<string>();
    }

    public class Scope
    {
        /// <summary>
        /// API资源可访问单元
        /// </summary>
        public List<string> ClaimTypes { get; set; } = new List<string>();
    }
}