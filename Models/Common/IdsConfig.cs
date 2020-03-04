using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectApi.Models
{
    /// <summary>
    /// IdentityServer配置信息
    /// </summary>
    public class IdsConfig
    {
        /// <summary>
        /// API名称
        /// </summary>
        public string ApiName { get; set; }
        /// <summary>
        /// API密钥
        /// </summary>
        public string ApiSecret { get; set; }
        /// <summary>
        /// 认证URI
        /// </summary>
        public string Authority { get; set; }
    }
}
