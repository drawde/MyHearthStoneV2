using MyHearthStoneV2.Common;
using MyHearthStoneV2.DAL;
using MyHearthStoneV2.DAL.Impl;
using MyHearthStoneV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHearthStoneV2.Common.Util;
namespace MyHearthStoneV2.BLL
{
    public class ErrRecBll : BaseBLL<HS_ErrRec>
    {
        private IRepository<HS_ErrRec> _repository = new Repository<HS_ErrRec>();
        private ErrRecBll()
        {
        }
        public static ErrRecBll Instance = new ErrRecBll();

        public async Task AsyncInsert(HS_ErrRec ex)
        {
            using (MyHearthStoneV2Context context = new MyHearthStoneV2Context())
            {
                context.hs_errrec.Add(ex);
                var res = context.Entry(ex).GetValidationResult();
                if (res.IsValid)
                {
                    await context.SaveChangesAsync();
                }
                else
                {
                    Log.Default.Debug("Arguments:" + ex.Arguments);
                    Log.Default.Debug(res.ValidationErrors.ToJsonString());
                }
            }
        }
    }
}
