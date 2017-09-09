using MyHearthStoneV2.Common.JsonModel;
using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MyHearthStoneV2.BLL;

namespace MyHearthStoneV2.Web.Filters
{
    /// <summary>
    /// WEB层异常过滤器
    /// </summary>
    public class WebException : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            HS_ErrRec ex = new HS_ErrRec();
            try
            {
                ContentResult contentResult = new ContentResult();
                contentResult.Content = JsonStringResult.Error(OperateResCodeEnum.内部错误);
                filterContext.Result = contentResult;
                filterContext.ExceptionHandled = true;

                ex.Action = (filterContext.RouteData.Values["action"]).ToString();
                ex.AddTime = DateTime.Now;
                ex.Controller = (filterContext.RouteData.Values["controller"]).ToString();
                ex.ErrorMsg = filterContext.Exception.Message;
                ex.IP = StringUtil.GetIP();
                ex.StackTrace = filterContext.Exception.StackTrace;
                ErrRecBll.Instance.AsyncInsert(ex);
            }
            catch (Exception ep)
            {

            }
        }
    }
}
