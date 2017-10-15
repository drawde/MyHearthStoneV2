using MyHearthStoneV2.API.Filters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.BLL;
using Newtonsoft.Json;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Common;
using MyHearthStoneV2.Common.JsonModel;

namespace MyHearthStoneV2.API.Controllers
{
    public class SaloonController : Controller
    {
        [DataVerify]
        public ActionResult CreateOrUpdate()
        {
            var param = JObject.Parse(TempData["param"].TryParseString());
            string Name = param["Name"].TryParseString();
            string Password = param["Password"].TryParseString();
            string UserCode = param["UserCode"].TryParseString();

            HS_GameTable gt = new HS_GameTable();
            gt.CreateUserCode = UserCode;
            gt.Password = Password;
            gt.TableName = Name;

            var resModel = GameTableBll.Instance.AddOrUpdate(gt);
            return Content(JsonConvert.SerializeObject(resModel));
        }

        [DataVerify]
        public ActionResult GetSaloons()
        {
            var param = JObject.Parse(TempData["param"].TryParseString());
            int PageSize = param["PageSize"].TryParseInt();
            int PageNo = param["PageNo"].TryParseInt();

            var where = LDMFilter.True<HS_GameTable>();
            var resModel = GameTableBll.Instance.GetPage(where, "id", PageNo, PageSize, false);
            return Content(JsonStringResult.SuccessPageResult(resModel));
        }

        [DataVerify]
        public ActionResult ZhanZuoEr()
        {
            var param = JObject.Parse(TempData["param"].TryParseString());
            string tableCode = param["TableCode"].TryParseString();
            string UserCode = param["UserCode"].TryParseString();
            string Password = param["Password"].TryParseString();

            var resModel = GameTableBll.Instance.ZhanZuoEr(tableCode, UserCode, Password);
            return Content(JsonConvert.SerializeObject(resModel));
        }
    }
}