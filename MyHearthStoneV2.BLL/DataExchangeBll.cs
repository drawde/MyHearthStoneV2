using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.DAL;
using MyHearthStoneV2.DAL.Impl;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Common.Util;

namespace MyHearthStoneV2.BLL
{
    public class DataExchangeBll : BaseBLL<HS_DataExchange>
    {
        private IRepository<HS_DataExchange> _repository = new Repository<HS_DataExchange>();
        private DataExchangeBll()
        {
        }
        public static DataExchangeBll Instance = new DataExchangeBll();

        public void AsyncInsert(string Action, string Controller, string QueryData, string ResultData, DataSourceEnum dataSource = DataSourceEnum.API)
        {
            HS_DataExchange rec = new HS_DataExchange();
            rec.Action = Action;
            rec.AddTime = DateTime.Now;
            rec.Controller = Controller;
            rec.IP = StringUtil.GetIP();
            rec.QueryData = QueryData;
            rec.ResultData = ResultData;
            rec.URL = "/" + rec.Controller + "/" + rec.Action;
            rec.DataSource = (int)dataSource;
            //var res = Insert(rec);
            AsyncInsert(rec);
        }
    }
}
