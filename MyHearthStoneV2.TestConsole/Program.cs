using MyHearthStoneV2.BLL;
using MyHearthStoneV2.Game;
using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.Classical;
using MyHearthStoneV2.Game.CardLibrary.Servant.Neutral.NAXX;
using MyHearthStoneV2.Common;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Redis;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
namespace MyHearthStoneV2.TestConsole
{
    class Program
    {
        static List<string> lstttttttt = new List<string>();
        static void Main(string[] args)
        {
            //var t = new GuiLingZhiZhu().GetType();
            //Console.WriteLine(new GuiLingZhiZhu().GetType().FullName);
            //Console.WriteLine(typeof(GuiLingZhiZhu).FullName);

            CardUtil.AddToRedis();
            //string code = ShortCodeBll.Instance.CreateCode("test", ShortCodeTypeEnum.CardGroupCode);
            //ShortCodeBll.Instance.SaveToDB();


            //CardUtil.AddToRedis();
            //using (var redisClient = RedisManager.GetClient())
            //{
            //    LinkedList<HS_ShortCode> ll = redisClient.Get<LinkedList<HS_ShortCode>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.ShortCodeKey));
            //}

            addd(lstttttttt);
            Console.ReadKey();
        }

        public static void addd(List<string> dddd)
        {
            dddd.Add("adadadasdadadadasd");
        }
    }
}
