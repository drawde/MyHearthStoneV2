using MyHearthStoneV2.Common.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using ServiceStack.Redis;
using MyHearthStoneV2.Redis;
using System.Configuration;

namespace MyHearthStoneV2.API.Controllers
{
    public class DefaultController : ApiController
    {
        [HttpPost]
        [HttpGet]
        public string Index()
        {
            using (var redisClient = RedisManager.GetClient())
            {
                redisClient.Set<string>("drawde", "hahahahahahah");
                string res = redisClient.Get<string>("drawde");

                return OperateJsonRes.SuccessResult(res);
            }
            //RedisClient rc = new RedisClient("123.56.130.111", 6379, "vweoinNFiu349*934#2sdfJJoJFjMQQKq");//
            //rc.Set<string>("drawde", "hahahahahahah");
            //string res = rc.Get<string>("drawde");

            //return OperateJsonRes.SuccessResult(res);
            //return new HttpResponseMessage { Content = new StringContent(OperateJsonRes.Error(Common.Enum.OperateResCodeEnum.不能提交重复数据), System.Text.Encoding.UTF8, "application/json") };
            //return Json<string>(OperateJsonRes.SuccessResult());
        }

        [HttpPost]
        [HttpGet]
        public string Config()
        {
            return ConfigurationManager.AppSettings["TestKey"];
        }
    }
}
