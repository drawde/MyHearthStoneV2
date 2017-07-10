using MyHearthStoneV2.Common;
using MyHearthStoneV2.DAL;
using MyHearthStoneV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.DAL.Impl;
using MyHearthStoneV2.Common.JsonModel;
using MyHearthStoneV2.Common.Enum;
using Newtonsoft.Json;

namespace MyHearthStoneV2.BLL
{
      
    public class BaseBLL<T> where T : BaseEntity
    {
        private IRepository<T> _repository;

        public BaseBLL()
        {
            _repository = new Repository<T>();
        }
        public IPagedItemsResult<T> GetPage(Expression<Func<T, bool>> filter = null, string orderBy = null, int? page = null, int? pageSize = null, bool? asc = null)
        {
            var data = _repository.Get(filter, orderBy, page, pageSize, asc);
            return data.Result;
        }

        public T GetById(int Id)
        {
            return _repository.GetByKey(Id).Result;

        }

        public int Update(T entity)
        {
            return _repository.Update(entity).Result;            
        }


        public int Insert(T entity)
        {
            return _repository.Insert(entity).Result;
        }

        public int Delete(int id)
        {
            return _repository.Delete(id).Result;
        }

        public async Task<int> AsyncUpdate(T entity)
        {
            return await _repository.Update(entity);
        }


        public async Task<int> AsyncInsert(T entity)
        {
            return await _repository.Insert(entity);
        }
    }
}
