using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectApi.Helpers
{
    /// <summary>
    /// 正则帮助类
    /// </summary>
    public static class RegularHelper
    {
        public const string Uri = @"(https?|ftp|file)://[-A-Za-z0-9+&@#/%?=~_|!:,.;]+[-A-Za-z0-9+&@#/%=~_|]";
    }
}
