using MyHearthStoneV2.BLL;
using MyHearthStoneV2.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using MyHearthStoneV2.Common.Util;


namespace MyHearthStoneV2.BLL.PageAttribute
{
    /// <summary>
    /// 接口访问记录器
    /// </summary>
    public class RecordDataExchangeAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            try
            {
                ContentResult cr = (ContentResult)filterContext.Result;
                string response = cr.Content;
                DataExchangeBll.Instance.AsyncInsert((filterContext.RouteData.Values["action"]).ToString(), (filterContext.RouteData.Values["controller"]).ToString(), filterContext.Controller.TempData["fullData"].TryParseString(), response);
            }
            catch (Exception)
            {

            }
            base.OnResultExecuted(filterContext);
        }
    }
}
