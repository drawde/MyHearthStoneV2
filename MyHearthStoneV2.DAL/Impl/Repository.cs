using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using MyHearthStoneV2.Common;

namespace MyHearthStoneV2.DAL.Impl
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IUnitOfWorkContext _unitOfWork;
        private readonly DbSet<TEntity> _dbSet;

        public Repository()
        {
            _unitOfWork = new UnitOfWorkContext();
            _dbSet = _unitOfWork.Set<TEntity>();
        }

        #region 属性

        public virtual IQueryable<TEntity> Entities
        {
            get { return _dbSet; }
        }

        #endregion

        #region 公共方法

        public virtual Task<int> Insert(TEntity entity, bool isSave = true)
        {
            _unitOfWork.RegisterNew(entity);
            var query = isSave ? _unitOfWork.Commit() : 0;

            var taskSource = new TaskCompletionSource<int>();
            taskSource.SetResult(query);

            return taskSource.Task;
        }

        public virtual Task<int> Insert(IEnumerable<TEntity> entities, bool isSave = true)
        {
            _unitOfWork.RegisterNew(entities);
            var query = isSave ? _unitOfWork.Commit() : 0;

            var taskSource = new TaskCompletionSource<int>();
            taskSource.SetResult(query);

            return taskSource.Task;
        }

        public async virtual Task<int> Delete(object id, bool isSave = true)
        {
            TEntity entity = _dbSet.Find(id);
            return entity != null ? await Delete(entity, isSave) : 0;
        }

        public virtual Task<int> Delete(TEntity entity, bool isSave = true)
        {
            _unitOfWork.RegisterDeleted(entity);
            var query = isSave ? _unitOfWork.Commit() : 0;

            var taskSource = new TaskCompletionSource<int>();
            taskSource.SetResult(query);

            return taskSource.Task;
        }

        public virtual Task<int> Delete(IEnumerable<TEntity> entities, bool isSave = true)
        {
            _unitOfWork.RegisterDeleted(entities);
            var query = isSave ? _unitOfWork.Commit() : 0;

            var taskSource = new TaskCompletionSource<int>();
            taskSource.SetResult(query);

            return taskSource.Task;
        }

        public async virtual Task<int> Delete(Expression<Func<TEntity, bool>> filter, bool isSave = true)
        {
            List<TEntity> entities = _dbSet.Where(filter).ToList();
            return entities.Count > 0 ? await Delete(entities, isSave) : 0;
        }

        public virtual Task<int> Update(TEntity entity, bool isSave = true)
        {
            _unitOfWork.RegisterModified(entity);
            var query = isSave ? _unitOfWork.Commit() : 0;

            var taskSource = new TaskCompletionSource<int>();
            taskSource.SetResult(query);

            return taskSource.Task;
        }

        public virtual Task<TEntity> GetByKey(object key)
        {
            var query = _dbSet.Find(key);

            var taskSource = new TaskCompletionSource<TEntity>();
            taskSource.SetResult(query);

            return taskSource.Task;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        public virtual Task<IPagedItemsResult<TEntity>> Get(
             Expression<Func<TEntity, bool>> filter = null,
            string orderBy = null,
            int? page = null,
            int? pageSize = null,
            bool? asc = null
            )
        {

            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var totalCount = query.Count();

            if (orderBy != null)
            {
                query = query.OrderBy(orderBy, asc.Value ? "asc" : "desc");
            }
            else
            {
                query = query.OrderByName("id", "asc");
            }
            
            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }

            IPagedItemsResult<TEntity> result = new PageResult<TEntity>();
            result.TotalItemsCount = totalCount;
            result.Items = query;

            var taskSource = new TaskCompletionSource<IPagedItemsResult<TEntity>>();
            taskSource.SetResult(result);
            return taskSource.Task;
        }
        public virtual Task<IQueryable<TEntity>> GetItemByColumn(Expression<Func<TEntity, bool>> filter = null) {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            var taskSource = new TaskCompletionSource<IQueryable<TEntity>>();
            taskSource.SetResult(query);
            return taskSource.Task;
        }

        /// <summary>
        /// 列表查询(无分页)
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="asc"></param>
        /// <returns></returns>
        public virtual Task<IPagedItemsResult<TEntity>> GetList(
             Expression<Func<TEntity, bool>> filter = null,
            string orderBy = null,
            bool? asc = null
            )
        {

            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var totalCount = query.Count();

            if (orderBy != null)
            {
                query = query.OrderBy(orderBy, asc.Value ? "asc" : "desc");
            }
            else
            {
                query = query.OrderByName("id", "asc");
            }

            

            IPagedItemsResult<TEntity> result = new PageResult<TEntity>();
            result.TotalItemsCount = totalCount;
            result.Items = query;

            var taskSource = new TaskCompletionSource<IPagedItemsResult<TEntity>>();
            taskSource.SetResult(result);
            return taskSource.Task;
        }
        #endregion
    }
}
