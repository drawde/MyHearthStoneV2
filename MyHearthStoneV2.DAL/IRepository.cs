using MyHearthStoneV2.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.DAL
{
    /// <summary>
    ///     定义仓储模型中的数据标准操作
    /// </summary>
    /// <typeparam name="TEntity">动态实体类型</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        #region 属性

        IQueryable<TEntity> Entities { get; }

        #endregion

        #region 公共方法

        Task<int> Insert(TEntity entity, bool isSave = true);

        Task<int> Insert(IEnumerable<TEntity> entities, bool isSave = true);

        Task<int> Delete(object id, bool isSave = true);

        Task<int> Delete(TEntity entity, bool isSave = true);

        Task<int> Delete(IEnumerable<TEntity> entities, bool isSave = true);

        Task<int> Delete(Expression<Func<TEntity, bool>> predicate, bool isSave = true);

        Task<int> Update(TEntity entity, bool isSave = true);

        /// <summary>
        /// 根据主键获取实体对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<TEntity> GetByKey(object key);

            
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        Task<IPagedItemsResult<TEntity>> Get(
             Expression<Func<TEntity, bool>> filter = null,
            string orderBy = null,
            int? page = null,
            int? pageSize = null,
            bool? asc = null
            );

        /// <summary>
        /// 根据特定字段查询数据
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<IQueryable<TEntity>> GetItemByColumn(Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        /// 列表查询（无分页）
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        Task<IPagedItemsResult<TEntity>> GetList(
             Expression<Func<TEntity, bool>> filter = null,
            string orderBy = null,
            bool? asc = null
            );
        #endregion
    }
}
