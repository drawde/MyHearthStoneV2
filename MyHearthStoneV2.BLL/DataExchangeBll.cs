using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.DAL;
using MyHearthStoneV2.DAL.Impl;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Common;

namespace MyHearthStoneV2.BLL
{
    public class DataExchangeBll : BaseBLL<HS_DataExchange>
    {
        private IRepository<HS_DataExchange> _repository = new Repository<HS_DataExchange>();
        private DataExchangeBll()
        {
        }
        public static DataExchangeBll Instance = new DataExchangeBll();

        public async Task AsyncInsert(string Action, string Controller, string QueryData, string ResultData, DataSourceEnum dataSource = DataSourceEnum.API)
        {
            using (MyHearthStoneV2Context context = new MyHearthStoneV2Context())
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
                //rec.DataCode = RandomUtil.CreateRandomStr(10);

                context.hs_dataexchange.Add(rec);
                var res = context.Entry(rec).GetValidationResult();
                if (res.IsValid)
                {
                    await context.SaveChangesAsync();
                }
                else
                {
                    Log.Default.Debug(res.ValidationErrors.ToJsonString());
                }
            }
        }
    }
}
