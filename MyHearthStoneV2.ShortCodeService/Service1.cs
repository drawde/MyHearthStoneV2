using MyHearthStoneV2.BLL;
using MyHearthStoneV2.Common;
using MyHearthStoneV2.Redis;
using MyHearthStoneV2.ShortCodeBll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.ShortCodeService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                MyHearthStoneV2.Common.Log.Default.Debug("ShortCodeService启动...");
                int saveCount = ShortCodeBusiness.Instance.SaveToDB();
                MyHearthStoneV2.Common.Log.Default.Debug("ShortCodeService执行完毕...更新了（" + saveCount + "）条数据");
            }
            catch (Exception ex)
            {
                MyHearthStoneV2.Common.Log.Default.Error(ex);
            }
        }

        protected override void OnStop()
        {
        }
    }
}
