using GeetestSDK;
using MyHearthStoneV2.BLL;
using MyHearthStoneV2.Common.Common;
using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Common.JsonModel;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Model.CustomModels;
using MyHearthStoneV2.VerificationCode;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHearthStoneV2.HearthStoneWeb.Controllers
{
    public class UserCentreController : Controller
    {
        // GET: UserCentre
        public ActionResult Register()
        {            
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult GetCaptcha()
        {
            GeetestLib geetest = new GeetestLib(GeetestConfig.publicKey, GeetestConfig.privateKey);
            string userID = RandomUtil.CreateRandomStr(10);
            byte gtServerStatus = geetest.preProcess(userID, "web", ConfigurationManager.AppSettings["ClientIP"]);
            Session[GeetestLib.gtServerStatusSessionKey] = gtServerStatus;
            Session["userID"] = userID;
            return Content(geetest.getResponseStr());
        }

        public ActionResult ValidateCode()
        {
            string res = OperateJsonRes.Error(OperateResCodeEnum.验证码错误);
            if (GeetestValidate.Validate())
            {
                res = OperateJsonRes.SuccessResult();
            }
            return Content(res);
        }

        public ActionResult DoRegister()
        {
            string res = OperateJsonRes.VerifyFail();
            try
            {
                if (GeetestValidate.Validate())
                {
                    res = UsersBll.Instance.Register(Request["UserName"].TryParseString(), Request["Password"].TryParseString(), Request["Mobile"].TryParseString(),
                        Request["Email"].TryParseString(), Request["InvitationCode"].TryParseString(), Request["NickName"].TryParseString(), Request["HeadImg"].TryParseString());
                    var objRes = JsonConvert.DeserializeObject<APIResultBase>(res);
                    if (objRes.code == (int)OperateResCodeEnum.成功)
                    {
                        string user = JsonConvert.SerializeObject(UsersBll.Instance.GetUserByUserName(Request["UserName"].TryParseString()), new JsonSerializerSettings
                        {
                            DateFormatString = "yyyy-MM-dd HH:mm:ss"
                        });
                        CookieHelper.SetCookie("User", user, DateTime.Now.AddDays(30));
                    }
                }
                else
                {
                    res = OperateJsonRes.Error(OperateResCodeEnum.验证码错误);
                }
            }
            catch (Exception ex)
            {
                res = OperateJsonRes.Error(OperateResCodeEnum.内部错误);
            }
            return Content(res);
        }

        public ActionResult DoLogin()
        {
            string res = OperateJsonRes.VerifyFail();
            try
            {
                if (GeetestValidate.Validate())
                {
                    CUsers user = UsersBll.Instance.Login(Request["LoginName"].TryParseString(), Request["Password"].TryParseString());
                    if (user != null)
                    {
                        string userJson = JsonConvert.SerializeObject(user, new JsonSerializerSettings
                        {
                            DateFormatString = "yyyy-MM-dd HH:mm:ss"
                        });
                        CookieHelper.SetCookie("User", userJson, DateTime.Now.AddDays(30));
                        res = OperateJsonRes.SuccessResult();
                    }
                    else
                    {
                        res = OperateJsonRes.Error(OperateResCodeEnum.用户名或密码错误);
                    }
                }
                else
                {
                    res = OperateJsonRes.Error(OperateResCodeEnum.验证码错误);
                }
            }
            catch (Exception ex)
            {
                res = OperateJsonRes.Error(OperateResCodeEnum.内部错误);
            }
            return Content(res);
        }


        public ActionResult DoLogOut()
        {
            string res = OperateJsonRes.VerifyFail();
            try
            {
                CookieHelper.RemoveCookie("User");
                res = OperateJsonRes.SuccessResult();
            }
            catch (Exception ex)
            {
                res = OperateJsonRes.Error(OperateResCodeEnum.内部错误);
            }
            return Content(res);
        }
    }
}