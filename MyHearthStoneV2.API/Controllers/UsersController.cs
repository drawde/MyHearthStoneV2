using MyHearthStoneV2.BLL;
using MyHearthStoneV2.API.Filters;
using MyHearthStoneV2.Common.JsonModel;
using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Common.Util;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using MyHearthStoneV2.Common;
using MyHearthStoneV2.Model;

namespace MyHearthStoneV2.API.Controllers
{
    public class UsersController : Controller
    {
        //[DataVerify(false)]
        //public ActionResult Register()
        //{
        //    string res = OperateJsonRes.VerifyFail();
        //    //转化成json对象
        //    var param = JObject.Parse(TempData["param"].TryParseString());

        //    res = UsersBll.Instance.Register(param["UserName"].TryParseString(), param["Password"].TryParseString(), param["Mobile"].TryParseString(),
        //        param["Email"].TryParseString(), param["InvitationCode"].TryParseString(), param["NickName"].TryParseString(), param["HeadImg"].TryParseString());
        //    return Content(res);
        //}

        [DataVerify(false)]
        public ActionResult ValidateUserName()
        {
            string res = JsonStringResult.VerifyFail();
            var param = JObject.Parse(TempData["param"].TryParseString());
            res = UsersBll.Instance.IsRepeat(param["UserName"].TryParseString()) ? JsonStringResult.Error(OperateResCodeEnum.用户名重复) : JsonStringResult.SuccessResult();
            return Content(res);
        }

        [DataVerify]
        public ActionResult SaveCardGroup()
        {
            var param = JObject.Parse(TempData["param"].TryParseString());
            string GroupName = param["GroupName"].TryParseString();
            string Cards = param["Cards"].TryParseString();
            string GroupCode = param["GroupCode"].TryParseString();
            string Profession = param["Profession"].TryParseString();
            string UserCode = param["UserCode"].TryParseString();
            var resModel = UserCardGroupBll.Instance.AddOrUpdateCardGroup(UserCode, GroupCode, GroupName, Profession, Cards);
            return Content(JsonConvert.SerializeObject(resModel));
        }

        [DataVerify]
        public ActionResult GetCardGroups()
        {
            var param = JObject.Parse(TempData["param"].TryParseString());
            int PageSize = param["PageSize"].TryParseInt();
            int PageNo = param["PageNo"].TryParseInt();
            string UserCode = param["UserCode"].TryParseString();

            var where = LDMFilter.True<HS_UserCardGroup>();
            where = where.And(c => c.UserCode == UserCode);
            var resModel = UserCardGroupBll.Instance.GetPage(where, "id", PageNo, PageSize, false);
            return Content(JsonStringResult.SuccessPageResult(resModel));
        }
    }
}