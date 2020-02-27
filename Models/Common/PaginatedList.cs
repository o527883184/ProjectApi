using System.Collections.Generic;

namespace ProjectApi.Models
{
    /// <summary>
    /// 分页数据返回类
    /// </summary>
    public class PaginatedList<T> : List<T> where T : class
    {
        public PaginationParameters PaginationParameters { get; }

        /// <summary>
        /// 数据总数
        /// </summary>
        public long TotalCount { get; set; }
        /// <summary>
        /// 页码总数
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 是否有上一页
        /// </summary>
        public bool HasPre { get; set; }
        /// <summary>
        /// 是否有下一页
        /// </summary>
        public bool HasNext { get; set; }

        /// <summary>
        /// 分页数据返回类
        /// </summary>
        public PaginatedList()
        {
        }

        /// <summary>
        /// 分页数据返回类
        /// </summary>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="totalCount">数据总数</param>
        /// <param name="data">数据</param>
        /// <param name="sortField">排序字段</param>
        /// <param name="isAsc">是否升序</param>
        public PaginatedList(int pageNumber, int pageSize, long totalCount, List<T> data, string sortField, bool isAsc)
        {
            PaginationParameters = new PaginationParameters
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                SortBy = sortField,
                IsAsc = isAsc
            };
            TotalCount = totalCount;
            PageCount = (int)TotalCount / PaginationParameters.PageSize + (TotalCount % PaginationParameters.PageSize > 0 ? 1 : 0);
            HasPre = PaginationParameters.PageNumber > 1;
            HasNext = PaginationParameters.PageNumber < PageCount;

            AddRange(data);
        }
    }
}
