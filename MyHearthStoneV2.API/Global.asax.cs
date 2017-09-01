using Microsoft.AspNet.SignalR;
using MyHearthStoneV2.BLL;
using MyHearthStoneV2.CardLibrary;
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace MyHearthStoneV2.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var config = new HubConfiguration();
            //config.EnableCrossDomain = true;
            AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            CardUtil.AddToRedis();
            using (var redisClient = RedisManager.GetClient())
            {
                //设置超级管理员
                redisClient.Set<string>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.SuperAdminUserCode), "58657C04BCADF3C6AA26F2B79D24994D");

                redisClient.Set<string>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CSSAndJSVersion), SystemConfigBll.Instance.GetValueByKey(RedisCategoryKeyEnum.CSSAndJSVersion.ToString())); 
            }
        }
    }
}
