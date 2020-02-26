using ProjectApi.Interfaces;

namespace ProjectApi.Models
{
    /// <summary>
    /// 分页请求参数基类
    /// </summary>
    public class PaginationBase
    {
        private const int DefaultPageSize = 10;
        private const int DefaultMaxPageSize = 100;
        private const string DefaultOrderBy = nameof(IEntity.Id);

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
        public virtual int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > 0 ? value : DefaultPageSize;
        }

        private int _maxPageSize = DefaultMaxPageSize;
        /// <summary>
        /// 最大页大小
        /// </summary>
        public virtual int MaxPageSize
        {
            get => _maxPageSize;
            set => _maxPageSize = value > 0 && value < DefaultMaxPageSize ? value : DefaultMaxPageSize;
        }

        /// <summary>
        /// 默认排序(Id)
        /// </summary>
        private string _orderBy = DefaultOrderBy;
        /// <summary>
        /// 排序
        /// </summary>
        public string OrderBy
        {
            get => _orderBy;
            set => _orderBy = value ?? DefaultOrderBy;
        }
    }
}
