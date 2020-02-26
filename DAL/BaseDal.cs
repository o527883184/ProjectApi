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
    public class BaseDal<T> : IBaseDal<T> where T : class, IEntity
    {
        private readonly MogoContext _mogoContext;
        private readonly ILogger<BaseDal<T>> _logger;
        private readonly IMongoCollection<T> _col;

        public BaseDal(MogoContext mogoContext, ILogger<BaseDal<T>> logger)
        {
            _mogoContext = mogoContext;
            _logger = logger;
            _col = _mogoContext.GetCollection<T>(nameof(T).ToLower());
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

        public async Task<IEnumerable<T>> SearchAsync() => await SearchAsync();

        public async Task<IEnumerable<T>> SearchAsync<TField>(string field, TField value) => await SearchAsync(Builders<T>.Filter.Eq(field, value));

        public async Task<IEnumerable<T>> SearchAsync(FilterDefinition<T> filter) => await SearchAsync(filter);

        public async Task<IEnumerable<T>> SearchAsync(string sortField, bool isAsc = true) => await SearchAsync(sort: isAsc ? Builders<T>.Sort.Ascending(sortField) : Builders<T>.Sort.Descending(sortField));

        public async Task<IEnumerable<T>> SearchAsync(SortDefinition<T> sort) => await SearchAsync(sort: sort);

        public async Task<IEnumerable<T>> SearchAsync(FilterDefinition<T> filter = null, SortDefinition<T> sort = null)
        {
            if (filter != null && sort != null)
                return await _col.Find(filter).Sort(sort).ToListAsync();

            if (filter == null)
                return await _col.Find(Builders<T>.Filter.Empty).Sort(sort).ToListAsync();

            if (sort == null)
                return await _col.Find(filter).ToListAsync();

            return await _col.Find(Builders<T>.Filter.Empty).ToListAsync();
        }

        public async Task<PaginatedList<T>> SearchAsync(int pageIndex, int pageSize) => await SearchAsync(pageIndex, pageSize);

        public async Task<PaginatedList<T>> SearchAsync(int pageIndex, int pageSize, string sortField, bool isAsc = true) => await SearchAsync(pageIndex, pageSize, sort: isAsc ? Builders<T>.Sort.Ascending(sortField) : Builders<T>.Sort.Descending(sortField));

        public async Task<PaginatedList<T>> SearchAsync<TField>(int pageIndex, int pageSize, string field, TField value) => await SearchAsync(pageIndex, pageSize, Builders<T>.Filter.Eq(field, value));

        public async Task<PaginatedList<T>> SearchAsync<TField>(int pageIndex, int pageSize, string field, TField value, string sortField, bool isAsc = true) => await SearchAsync(pageIndex, pageSize, Builders<T>.Filter.Eq(field, value), isAsc ? Builders<T>.Sort.Ascending(sortField) : Builders<T>.Sort.Descending(sortField));

        public async Task<PaginatedList<T>> SearchAsync(int pageIndex, int pageSize, FilterDefinition<T> filter) => await SearchAsync(pageIndex, pageSize, filter);

        public async Task<PaginatedList<T>> SearchAsync<TField>(int pageIndex, int pageSize, FilterDefinition<T> filter, string sortField, bool isAsc = true) => await SearchAsync(pageIndex, pageSize, filter, isAsc ? Builders<T>.Sort.Ascending(sortField) : Builders<T>.Sort.Descending(sortField));

        public async Task<PaginatedList<T>> SearchAsync(int pageIndex = 0, int pageSize = 20, FilterDefinition<T> filter = null, SortDefinition<T> sort = null)
        {
            var data = new List<T>();
            var total = 0L;

            if (filter != null && sort != null)
            {
                data = await _col.Find(filter).Sort(sort).Skip(pageIndex).Limit(pageSize).ToListAsync();
                total = await GetCountAsync(filter);
            }
            else if (filter != null)
            {
                data = await _col.Find(filter).Skip(pageIndex).Limit(pageSize).ToListAsync();
                total = await GetCountAsync(filter);
            }
            else if (sort != null)
            {
                data = await _col.Find(filter).Sort(sort).Skip(pageIndex).Limit(pageSize).ToListAsync();
                total = await GetCountAsync();
            }

            return new PaginatedList<T>(pageIndex, pageSize, total, data);
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
