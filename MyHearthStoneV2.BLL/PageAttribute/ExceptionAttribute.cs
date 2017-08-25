using MyHearthStoneV2.BLL;
using MyHearthStoneV2.Common.Common;
using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MyHearthStoneV2.Common.Util;
namespace MyHearthStoneV2.BLL.PageAttribute
{
    /// <summary>
    /// 接口异常处理器
    /// </summary>
    public class ExceptionAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            HS_ErrRec ex = new HS_ErrRec();
            try
            {
                ContentResult contentResult = new ContentResult();
                contentResult.Content = OperateJsonRes.Error(OperateResCodeEnum.内部错误);
                filterContext.Result = contentResult;
                filterContext.ExceptionHandled = true;
                
                ex.Action = (filterContext.RouteData.Values["action"]).ToString();
                ex.AddTime = DateTime.Now;
                ex.Controller = (filterContext.RouteData.Values["controller"]).ToString();
                ex.ErrorMsg = filterContext.Exception.Message;
                ex.IP = StringUtil.GetIP();
                ex.StackTrace = filterContext.Exception.StackTrace;
                var res = ErrRecBll.Instance.AsyncInsert(ex);

                var excRes = DataExchangeBll.Instance.AsyncInsert((filterContext.RouteData.Values["action"]).ToString(), (filterContext.RouteData.Values["controller"]).ToString(),
                    filterContext.Controller.TempData["fullData"].TryParseString(), contentResult.Content);
            }
            catch (Exception)
            {
                
            }
            //filterContext.HttpContext.Response.Clear();
            //filterContext.HttpContext.Response.StatusCode = 200;
            //filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;       
        }
    }
}
