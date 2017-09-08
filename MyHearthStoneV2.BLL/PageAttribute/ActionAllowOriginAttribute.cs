using MyHearthStoneV2.Common.JsonModel;
using MyHearthStoneV2.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyHearthStoneV2.BLL.PageAttribute
{
    /// <summary>
    /// 跨域访问控制器
    /// </summary>
    public class ActionAllowOriginAttribute : ActionFilterAttribute
    {
        public ActionAllowOriginAttribute()
        {
            Order = 1;
        }
        public string[] AllowSites
        {
            get
            {
                return new string[] { System.Configuration.ConfigurationManager.AppSettings["AllowedOrigin"] };
            }
            set
            {
            }
        }
        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            bool res = AllowOriginAttribute.onExcute(filterContext, AllowSites);
            ContentResult contentResult = new ContentResult();
            if (res == false)
            {
                contentResult.Content = Common.JsonModel.JsonStringResult.Error(OperateResCodeEnum.没有访问权限);
                filterContext.Result = contentResult;
                return;
            }
        }

    }
}
