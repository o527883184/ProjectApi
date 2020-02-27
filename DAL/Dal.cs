using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using ProjectApi.Data;
using ProjectApi.Interfaces;
using ProjectApi.Models;

namespace ProjectApi.DAL
{
    /// <summary>
    /// 数据访问基本方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Dal<T> : IDal<T> where T : class, IEntity
    {
        private readonly MogoContext _mogoContext;
        private readonly ILogger<Dal<T>> _logger;
        private readonly IMongoCollection<T> _col;

        public Dal(MogoContext mogoContext, ILogger<Dal<T>> logger)
        {
            _mogoContext = mogoContext;
            _logger = logger;
            _col = _mogoContext.GetCollection<T>(typeof(T).Name.ToLower());
        }

        public async Task<int> CreateAsync(T entity)
        {
            await _col.InsertOneAsync(entity);
            return 1;
        }

        public async Task<int> DeleteAsync(string id) => await DeleteAsync("_id", id);

        public async Task<int> DeleteAsync<TField>(string field, TField value) => await DeleteAsync(Builders<T>.Filter.Eq(field, value));

        public async Task<int> DeleteAsync(FilterDefinition<T> filter)
        {
            await _col.DeleteOneAsync(filter);
            return 1;
        }

        public async Task<int> DeleteManyAsync<TField>(string field, TField value) => await DeleteManyAsync(Builders<T>.Filter.Eq(field, value));

        public async Task<int> DeleteManyAsync(FilterDefinition<T> filter)
        {
            await _col.DeleteManyAsync(filter);
            return 1;
        }

        public async Task<T> GetAsync(string id) => await GetAsync(Builders<T>.Filter.Eq("_id", id));

        public async Task<T> GetAsync<TField>(string field, TField value) => await GetAsync(Builders<T>.Filter.Eq(field, value));

        public async Task<T> GetAsync(FilterDefinition<T> filter) => await _col.Find(filter).FirstOrDefaultAsync();

        public async Task<long> GetCountAsync() => await _col.CountDocumentsAsync(Builders<T>.Filter.Empty);

        public async Task<long> GetCountAsync<TField>(string field, TField value) => await GetCountAsync(Builders<T>.Filter.Eq(field, value));

        public async Task<long> GetCountAsync(FilterDefinition<T> filter) => await _col.CountDocumentsAsync(filter);

        public async Task<IEnumerable<T>> SearchAsync() => await SearchByListAsync();

        public async Task<IEnumerable<T>> SearchAsync<TField>(string field, TField value) => await SearchByListAsync(Builders<T>.Filter.Eq(field, value));

        public async Task<IEnumerable<T>> SearchAsync(FilterDefinition<T> filter) => await SearchByListAsync(filter);

        public async Task<IEnumerable<T>> SearchAsync(string sortField, bool isAsc = true) => await SearchByListAsync(sort: isAsc ? Builders<T>.Sort.Ascending(sortField) : Builders<T>.Sort.Descending(sortField));

        public async Task<IEnumerable<T>> SearchAsync(SortDefinition<T> sort) => await SearchByListAsync(sort: sort);

        public async Task<IEnumerable<T>> SearchAsync(FilterDefinition<T> filter, SortDefinition<T> sort) => await SearchByListAsync(filter, sort);

        /// <summary>
        /// 集合数据查询
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <param name="sort">排序条件</param>
        /// <returns></returns>
        private async Task<IEnumerable<T>> SearchByListAsync(FilterDefinition<T> filter = null, SortDefinition<T> sort = null)
        {
            if (filter != null && sort != null)
                return await _col.Find(filter).Sort(sort).ToListAsync();

            if (filter == null)
                return await _col.Find(Builders<T>.Filter.Empty).Sort(sort).ToListAsync();

            if (sort == null)
                return await _col.Find(filter).ToListAsync();

            return await _col.Find(Builders<T>.Filter.Empty).ToListAsync();
        }

        public async Task<PaginatedList<T>> SearchAsync(int pageNumber, int pageSize) => await SearchByPaginatedAsync(pageNumber, pageSize, null, null);

        public async Task<PaginatedList<T>> SearchAsync(int pageNumber, int pageSize, string sortField, bool isAsc = true) => await SearchByPaginatedAsync(pageNumber, pageSize, null, isAsc ? Builders<T>.Sort.Ascending(sortField) : Builders<T>.Sort.Descending(sortField));

        public async Task<PaginatedList<T>> SearchAsync<TField>(int pageNumber, int pageSize, string field, TField value) => await SearchByPaginatedAsync(pageNumber, pageSize, Builders<T>.Filter.Eq(field, value), null);

        public async Task<PaginatedList<T>> SearchAsync<TField>(int pageNumber, int pageSize, string field, TField value, string sortField, bool isAsc = true) => await SearchByPaginatedAsync(pageNumber, pageSize, Builders<T>.Filter.Eq(field, value), isAsc ? Builders<T>.Sort.Ascending(sortField) : Builders<T>.Sort.Descending(sortField));

        public async Task<PaginatedList<T>> SearchAsync(int pageNumber, int pageSize, FilterDefinition<T> filter) => await SearchByPaginatedAsync(pageNumber, pageSize, filter, null);

        public async Task<PaginatedList<T>> SearchAsync<TField>(int pageNumber, int pageSize, FilterDefinition<T> filter, string sortField, bool isAsc = true) => await SearchByPaginatedAsync(pageNumber, pageSize, filter, isAsc ? Builders<T>.Sort.Ascending(sortField) : Builders<T>.Sort.Descending(sortField));

        public async Task<PaginatedList<T>> SearchAsync(int pageNumber, int pageSize, FilterDefinition<T> filter, SortDefinition<T> sort)
        => await SearchByPaginatedAsync(pageNumber, pageSize, filter, sort);

        /// <summary>
        /// 分页数据查询
        /// </summary>
        /// <param name="pageNumber">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="filter">过滤条件</param>
        /// <param name="sort">排序条件</param>
        /// <returns></returns>
        private async Task<PaginatedList<T>> SearchByPaginatedAsync(int pageNumber, int pageSize, FilterDefinition<T> filter, SortDefinition<T> sort)
        {
            var page = new PaginationBusiness(pageNumber, pageSize);
            var data = new List<T>();

            if (filter == null)
                filter = Builders<T>.Filter.Empty;

            var total = await GetCountAsync(filter);
            if (total > 0)
            {
                if (sort != null)
                    data = await _col.Find(filter).Sort(sort).Skip(page.Skip).Limit(page.Limit).ToListAsync();
                else
                    data = await _col.Find(filter).Skip(page.Limit).Limit(page.Skip).ToListAsync();
            }

            return new PaginatedList<T>(pageNumber, pageSize, total, data);
        }

        public Task<int> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(string id, FilterDefinition<T> update)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync<TField>(string id, string field, TField value)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(FilterDefinition<T> filter, FilterDefinition<T> update)
        {
            throw new NotImplementedException();
        }
    }
}
