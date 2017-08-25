using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MyHearthStoneV2.Common.Util;
namespace MyHearthStoneV2.BLL.PageAttribute
{
    public class VersionCtlAttribute: AuthorizeAttribute
    {

        /// <summary>
        /// 设置加载顺序
        /// </summary>
        public VersionCtlAttribute()
        {
            Order = 3;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string version = filterContext.Controller.TempData["version"].TryParseString();
            if (!version.IsNullOrEmpty())
            {
                string controllerName = filterContext.RouteData.Values["controller"].ToString().ToLower();
                string actionName = filterContext.RouteData.Values["action"].ToString().ToLower();

                string currentUrl = "/" + controllerName + "/" + actionName;
                string targetUrl = "/" + controllerName + "/" + actionName + version.Replace(".", "");

                if (currentUrl != targetUrl)
                {
                    filterContext.Result = new RedirectResult(targetUrl);
                    return;
                }
            }
        }
    }
}
