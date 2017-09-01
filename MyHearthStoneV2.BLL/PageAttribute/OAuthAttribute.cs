using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Model.CustomModels;
using Newtonsoft.Json;
using MyHearthStoneV2.Common;

namespace MyHearthStoneV2.BLL.PageAttribute
{
    /// <summary>
    /// 用户授权验证
    /// </summary>
    public class OAuthAttribute : AuthorizeAttribute
    {

        /// <summary>
        /// 设置加载顺序
        /// </summary>
        public OAuthAttribute()
        {
            Order = 1;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string controllerName = filterContext.RouteData.Values["controller"].ToString().ToLower();
            string actionName = filterContext.RouteData.Values["action"].ToString().ToLower();
            string returnUrl = "/" + controllerName + "/" + actionName;

            string userJson = CookieHelper.GetCookieValue("User");
            //Log.Default.Debug(userJson);
            if (!userJson.IsNullOrEmpty())
            {
                CUsers user = null;
                try
                {
                    user = JsonConvert.DeserializeObject<CUsers>(userJson);
                    filterContext.Controller.ViewBag.User = UsersBll.Instance.GetUserByAdmin(user.UserCode);
                }
                catch (Exception ex)
                {
                    Log.Default.Error(ex);
                }
                if (user == null || UsersBll.Instance.IsUserCodeRepeat(user.UserCode) == false)
                {
                    SetContextResult(filterContext, returnUrl);
                    return;
                }
            }
            else
            {
                SetContextResult(filterContext, returnUrl);
                return;
            }
        }

        public void SetContextResult(AuthorizationContext filterContext,string returnUrl)
        {
            filterContext.Result = new RedirectResult("/UserCentre/Login?returnUrl=" + returnUrl);
        }
    }
}
