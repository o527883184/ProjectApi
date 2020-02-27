namespace ProjectApi.Models
{
    /// <summary>
    /// 分页请求参数类
    /// </summary>
    public class PaginationParameters : PaginationBase
    {
        private int _pageNumber = 1;
        /// <summary>
        /// 页码
        /// </summary>
        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = value > 0 ? value : _pageNumber;
        }

        private int _pageSize = DefaultPageSize;
        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > 0 ? value : DefaultPageSize;
        }

        /// <summary>
        /// 是否升序
        /// </summary>
        public bool IsAsc { get; set; }

        /// <summary>
        /// 默认排序(Id)
        /// </summary>
        private string _sortBy = DefaultsortBy;
        /// <summary>
        /// 排序
        /// </summary>
        public string SortBy
        {
            get => _sortBy;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _sortBy = DefaultsortBy;
                }
                else
                {
                    value = value.Trim();
                    if (value.StartsWith('-'))
                    {
                        _sortBy = value.Substring(1);
                        IsAsc = false;
                    }
                    else
                    {
                        _sortBy = value;
                        IsAsc = true;
                    }
                }
            }
        }
    }

    /// <summary>
    /// 分页请求参数业务类
    /// </summary>
    public class PaginationBusiness : PaginationBase
    {
        /// <summary>
        /// 索引
        /// </summary>
        public int Skip { get; set; }
        /// <summary>
        /// 限制
        /// </summary>
        public int Limit { get; set; }
        /// <summary>
        /// 分页参数转换
        /// </summary>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">页大小</param>
        public PaginationBusiness(int pageNumber, int pageSize)
        {
            Skip = (pageNumber - 1) * pageSize;
            Limit = pageSize;
        }
    }
}
