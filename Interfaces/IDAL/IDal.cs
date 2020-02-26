using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using ProjectApi.Models;

namespace ProjectApi.Interfaces
{
    /// <summary>
    /// DAL数据访问基本方法封装
    /// </summary>
    public interface IDal<T> where T : class, IEntity
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> CreateAsync(T entity);

        #region << Delete >>

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        Task<int> DeleteAsync(string id);

        /// <summary>
        /// 删除
        /// </summary>
        /// <typeparam name="TField"></typeparam>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns></returns>
        Task<int> DeleteAsync<TField>(string field, TField value);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns></returns>
        Task<int> DeleteAsync(FilterDefinition<T> filter);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="TField"></typeparam>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns></returns>
        Task<int> DeleteManyAsync<TField>(string field, TField value);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns></returns>
        Task<int> DeleteManyAsync(FilterDefinition<T> filter);

        #endregion

        #region << Update >>

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(T entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <param name="update">更新设置</param>
        /// <returns></returns>
        Task<int> UpdateAsync(string id, FilterDefinition<T> update);

        /// <summary>
        /// 更新
        /// </summary>
        /// <typeparam name="TField"></typeparam>
        /// <param name="id">主键ID</param>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns></returns>
        Task<int> UpdateAsync<TField>(string id, string field, TField value);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <param name="update">更新设置</param>
        /// <returns></returns>
        Task<int> UpdateAsync(FilterDefinition<T> filter, FilterDefinition<T> update);

        #endregion

        #region << Search >>

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        Task<T> GetAsync(string id);

        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="TField"></typeparam>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns></returns>
        Task<T> GetAsync<TField>(string field, TField value);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns></returns>
        Task<T> GetAsync(FilterDefinition<T> filter);

        /// <summary>
        /// 查询数据集合
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns></returns>
        Task<IEnumerable<T>> SearchAsync();

        /// <summary>
        /// 查询数据集合
        /// </summary>
        /// <typeparam name="TField"></typeparam>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns></returns>
        Task<IEnumerable<T>> SearchAsync<TField>(string field, TField value);

        /// <summary>
        /// 查询数据集合
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns></returns>
        Task<IEnumerable<T>> SearchAsync(FilterDefinition<T> filter);

        /// <summary>
        /// 查询数据集合
        /// </summary>
        /// <param name="sortField">排序字段</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        Task<IEnumerable<T>> SearchAsync(string sortField, bool isAsc = true);

        /// <summary>
        /// 查询数据集合
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="sort">排序条件</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        Task<IEnumerable<T>> SearchAsync(SortDefinition<T> sort);

        /// <summary>
        /// 查询数据集合
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="filter">过滤条件</param>
        /// <param name="sort">排序条件</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        Task<IEnumerable<T>> SearchAsync(FilterDefinition<T> filter, SortDefinition<T> sort);

        /// <summary>
        /// 查询分页数据集合
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <returns></returns>
        Task<PaginatedList<T>> SearchAsync(int pageIndex, int pageSize);

        /// <summary>
        /// 查询分页数据集合
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="sortField">排序字段</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        Task<PaginatedList<T>> SearchAsync(int pageIndex, int pageSize, string sortField, bool isAsc = true);

        /// <summary>
        /// 查询分页数据集合
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns></returns>
        Task<PaginatedList<T>> SearchAsync<TField>(int pageIndex, int pageSize, string field, TField value);

        /// <summary>
        /// 查询分页数据集合
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <param name="sortField">排序字段</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        Task<PaginatedList<T>> SearchAsync<TField>(int pageIndex, int pageSize, string field, TField value, string sortField, bool isAsc = true);

        /// <summary>
        /// 查询分页数据集合
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="filter">过滤条件</param>
        /// <returns></returns>
        Task<PaginatedList<T>> SearchAsync(int pageIndex, int pageSize, FilterDefinition<T> filter);

        /// <summary>
        /// 查询分页数据集合
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="filter">过滤条件</param>
        /// <param name="sortField">排序字段</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        Task<PaginatedList<T>> SearchAsync<TField>(int pageIndex, int pageSize, FilterDefinition<T> filter, string sortField, bool isAsc = true);

        /// <summary>
        /// 查询分页数据集合
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="filter">过滤条件</param>
        /// <param name="sort">排序条件</param>
        /// <returns></returns>
        Task<PaginatedList<T>> SearchAsync(int pageIndex, int pageSize, FilterDefinition<T> filter, SortDefinition<T> sort);

        /// <summary>
        /// 得到查询数量
        /// </summary>
        /// <returns></returns>
        Task<long> GetCountAsync();

        /// <summary>
        /// 得到查询数量
        /// </summary>
        /// <param name="field">字段名</param>
        /// <param name="value">字段值</param>
        /// <returns></returns>
        Task<long> GetCountAsync<TField>(string field, TField value);

        /// <summary>
        /// 得到查询数量
        /// </summary>
        /// <param name="filter">过滤条件</param>
        /// <returns></returns>
        Task<long> GetCountAsync(FilterDefinition<T> filter);

        #endregion

    }
}
