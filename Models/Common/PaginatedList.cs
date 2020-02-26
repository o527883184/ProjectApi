using System.Collections.Generic;

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
        public long TotalCount { get; set; }
        /// <summary>
        /// 页码总数
        /// </summary>
        public int PageCount => (int)TotalCount / PaginationBase.PageSize + (TotalCount % PaginationBase.PageSize > 0 ? 1 : 0);
        /// <summary>
        /// 是否有上一页
        /// </summary>
        public bool HasPre => PaginationBase.PageNumber > 1;
        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool HasNext => PaginationBase.PageNumber < PageCount;

        /// <summary>
        /// 分页数据返回类
        /// </summary>
        public PaginatedList()
        {
        }

        /// <summary>
        /// 分页数据返回类
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="data"></param>
        public PaginatedList(int pageNumber, int pageSize, long totalCount, List<T> data)
        {
            PaginationBase = new PaginationBase
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            TotalCount = totalCount;
            AddRange(data);
        }
    }
}
