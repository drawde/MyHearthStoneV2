using MyHearthStoneV2.BLL;
using MyHearthStoneV2.Common;
using MyHearthStoneV2.Redis;
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
                Log.Default.Debug("ShortCodeService启动...");
                int saveCount = ShortCodeBll.Instance.SaveToDB();
                Log.Default.Debug("ShortCodeService执行完毕...更新了（" + saveCount + "）条数据");
            }
            catch (Exception ex)
            {
                Log.Default.Error(ex);
            }
        }

        protected override void OnStop()
        {
        }
    }
}
