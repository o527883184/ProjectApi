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

        private int _pageIndex = 0;
        public int PageIndex
        {
            get => _pageIndex;
            set => _pageIndex = value >= 0 ? value : 0;
        }

        private int _pageSize = DefaultPageSize;
        public virtual int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > 0 ? value : DefaultPageSize;
        }

        private int _maxPageSize = DefaultMaxPageSize;
        public virtual int MaxPageSize
        {
            get => _maxPageSize;
            set => _maxPageSize = value > 0 && value < DefaultMaxPageSize ? value : DefaultMaxPageSize;
        }

        /// <summary>
        /// 默认排序(Id)
        /// </summary>
        private string _orderBy = DefaultOrderBy;
        public string OrderBy
        {
            get => _orderBy;
            set => _orderBy = value ?? DefaultOrderBy;
        }
    }
}
