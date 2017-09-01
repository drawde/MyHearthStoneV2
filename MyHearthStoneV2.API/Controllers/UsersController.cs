using MyHearthStoneV2.BLL;
using MyHearthStoneV2.BLL.PageAttribute;
using MyHearthStoneV2.Common.Common;
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
            string res = OperateJsonRes.VerifyFail();
            var param = JObject.Parse(TempData["param"].TryParseString());
            res = UsersBll.Instance.IsRepeat(param["UserName"].TryParseString()) ? OperateJsonRes.Error(OperateResCodeEnum.用户名重复) : OperateJsonRes.SuccessResult();
            return Content(res);
        }

        [DataVerify()]
        public ActionResult TestSign()
        {
            string res = OperateJsonRes.SuccessResult();

            return Content(res);
        }
    }
}