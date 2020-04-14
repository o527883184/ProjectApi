using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectApi.Models
{
    public class IdsApiResource_Create
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "API资源名称不能为空")]
        public string Name { get; set; }
        /// <summary>
        /// 显示名称
        /// </summary>
        [Required(ErrorMessage = "API资源显示名称不能为空")]
        public string DisplayName { get; set; }
        /// <summary>
        /// 密钥
        /// </summary>
        [Required(ErrorMessage = "API资源密钥不能为空")]
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

    //public class Scope
    //{
    //    /// <summary>
    //    /// API资源可访问单元
    //    /// </summary>
    //    public List<string> ClaimTypes { get; set; } = new List<string>();
    //}
}