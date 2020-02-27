using ProjectApi.Interfaces;

namespace ProjectApi.Models
{
    /// <summary>
    /// 分页请求参数基类
    /// </summary>
    public class PaginationBase
    {
        protected const int DefaultPageSize = 10;
        protected const int DefaultMaxPageSize = 100;
        protected const string DefaultsortBy = nameof(IEntity.Id);
        private int _maxPageSize = DefaultMaxPageSize;
        /// <summary>
        /// 最大页大小
        /// </summary>
        protected virtual int MaxPageSize
        {
            get => _maxPageSize;
            set => _maxPageSize = value > 0 && value < DefaultMaxPageSize ? value : DefaultMaxPageSize;
        }
    }
}
