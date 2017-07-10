using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.BLL;
using MyHearthStoneV2.Common.Common;
using MyHearthStoneV2.Common.Enum;
namespace MyHearthStoneV2.BLL.PageAttribute
{
    public class JurisdictionAttribute : AuthorizeAttribute
    {        
        /// <summary>
        /// 设置加载顺序
        /// </summary>
        public JurisdictionAttribute()
        {
            Order = 90;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {            
            ContentResult contentResult = new ContentResult();
            bool verifySuccess = false;
            //LoginToken_L loginToken = filterContext.Controller.TempData["LoginToken"] as LoginToken_L;
            //if (loginToken != null)
            //{
            //    UserRole_OP_BLL urBll = new UserRole_OP_BLL();
            //    ShopInfo_S_BLL shopBll = new ShopInfo_S_BLL();
            //    Funtion_OP_BLL funtionBll = new Funtion_OP_BLL();
            //    ShopInfo_S shop = shopBll.GetByUserID(loginToken.UserID, Common.Enum.ShopStatus.正常);
            //    if (shop != null)
            //    {
            //        int record = 0;
            //        var lst = funtionBll.GetShopFunction(shop.ID, "", int.MaxValue, 1, out record);
            //        if (record > 0)
            //        {
            //            string controllerName = (filterContext.RouteData.Values["controller"]).ToString().ToUpper();
            //            string actionName = (filterContext.RouteData.Values["action"]).ToString().ToUpper();

            //            //var test = lst.FirstOrDefault(c => c.FuntionURL == "/OP/GertFunctionList");
            //            verifySuccess = lst.Any(c => c.FuntionURL.TryParseString().ToUpper() == "/" + controllerName + "/" + actionName);
            //        }
            //    }

            //    if (verifySuccess == false)
            //    {
            //        contentResult.Content = OperateJsonRes.Error(OperateResCodeEnum.没有访问权限);
            //        filterContext.Result = contentResult;
            //    }                
            //}
        }
    }
}
