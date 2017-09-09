using MyHearthStoneV2.BLL;
using MyHearthStoneV2.Common.JsonModel;
using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MyHearthStoneV2.Common.Util;
using System.Web.Http.Filters;
using System.Web.Http.ExceptionHandling;
using System.Threading;
using System.Web.Http.Results;
using System.Net;
using System.Net.Http;
namespace MyHearthStoneV2.API.Filters
{
    /// <summary>
    /// 接口异常处理器
    /// </summary>
    public class ExceptionOrErrorFilter : ExceptionHandler
    {
        //public override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        //{
        //    HS_ErrRec ex = new HS_ErrRec();
        //    try
        //    {
        //        ex.Action = (context.RequestContext.RouteData.Values["action"]).ToString();
        //        ex.AddTime = DateTime.Now;
        //        ex.Controller = (context.RequestContext.RouteData.Values["controller"]).ToString();
        //        ex.ErrorMsg = context.Exception.Message;
        //        ex.IP = StringUtil.GetIP();
        //        ex.StackTrace = context.Exception.StackTrace;
        //        ErrRecBll.Instance.AsyncInsert(ex);

        //        //var excRes = DataExchangeBll.Instance.AsyncInsert((context.RequestContext.RouteData.Values["action"]).ToString(), (context.RequestContext.RouteData.Values["controller"]).ToString(),
        //        //    context.RequestContext.Controller.TempData["fullData"].TryParseString(), context.RequestContext);
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    context.Result = new ResponseMessageResult(context.Request.CreateResponse(HttpStatusCode.InternalServerError, new { Message = JsonStringResult.Error(OperateResCodeEnum.内部错误) }));
        //}
        
    }
}
