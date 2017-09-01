using MyHearthStoneV2.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MyHearthStoneV2.BLL.PageAttribute
{
    /// <summary>
    /// 页面变量管理器
    /// </summary>
    public class PageVariable : AuthorizeAttribute
    {

        /// <summary>
        /// 设置加载顺序
        /// </summary>
        public PageVariable()
        {
            Order = 99;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.Controller.TempData["cssAndJSVersion"] = "?v=" + SystemConfigBll.Instance.GetValueByCache(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CSSAndJSVersion));
        }
    }
}
