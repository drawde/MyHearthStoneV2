using MyHearthStoneV2.BLL.PageAttribute;
using MyHearthStoneV2.Common.JsonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHearthStoneV2.API.Controllers
{
    public class OptionController : Controller
    {
        /// <summary>
        /// 同步服务器时间
        /// </summary>
        /// <returns></returns>
        [DataVerify(false)]
        public ActionResult SyncTime()
        {
            return Content(JsonStringResult.SuccessResult(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
        }
    }
}