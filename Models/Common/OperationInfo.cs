using System;

namespace ProjectApi.Models
{
    /// <summary>
    /// 操作信息
    /// </summary>
    public class OperationInfo
    {
        public string CreateUserId { get; set; }
        public string CreateUserName { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string UpdateUserId { get; set; }
        public string UpdateUserName { get; set; }
        public DateTime UpdateDateTime { get; set; } = DateTime.Now;
    }
}
