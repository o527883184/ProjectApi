﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectApi.Models
{
    /// <summary>
    /// 分页数据返回类
    /// </summary>
    public class PaginatedList<T> : List<T> where T : class
    {
        public PaginationBase PaginationBase { get; }

        /// <summary>
        /// 数据总数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 页总数
        /// </summary>
        public int PageCount => TotalCount / PaginationBase.PageSize + (TotalCount % PaginationBase.PageSize > 0 ? 1 : 0);

        public bool HasPre => PaginationBase.PageIndex > 0;
        public bool HasNext => PaginationBase.PageIndex < PageCount - 1;

        public PaginatedList(int pageIndex, int pageSize, int totalCount, IEnumerable<T> data)
        {
            PaginationBase = new PaginationBase
            {
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            TotalCount = totalCount;
            AddRange(data);
        }
    }
}
