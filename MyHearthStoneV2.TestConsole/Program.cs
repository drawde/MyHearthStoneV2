using MyHearthStoneV2.BLL;
using MyHearthStoneV2.CardAction.Servant.NAXX;
using MyHearthStoneV2.CardEnum;
using MyHearthStoneV2.CardLibrary;
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Servant.Classical;
using MyHearthStoneV2.CardLibrary.Servant.NAXX;
using MyHearthStoneV2.Common;
using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.GameControler;
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
        static void Main(string[] args)
        {
            //ClassProxy.tc = new TestClass();
            //TestClass tt = new TestClass();
            //tt.ddada();

            //for (int x = 0; x < 0; x++)
            //{
            //    using (var redisClient = RedisManager.GetClient())
            //    {
            //        LinkedList<HS_ShortCode> ll = redisClient.Get<LinkedList<HS_ShortCode>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.ShortCodeKey));
            //        HS_ShortCode last = ll.Last.Value;
            //        string code = last.Code;
            //        string newCode = code;
            //        for (int i = code.Length - 1; i >= 0; i--)
            //        {
            //            int ascii = Encoding.ASCII.GetBytes(code[i].ToString())[0];

            //            switch (ascii)
            //            {
            //                case 57: ascii = 65; break;
            //                case 90: ascii = 97; break;
            //                case 122: ascii = 48; break;
            //                default: ascii++; break;
            //            }
            //            byte[] array = new byte[1];
            //            array[0] = (byte)(ascii);
            //            char[] chars = newCode.ToCharArray();
            //            chars[i] = Encoding.ASCII.GetChars(array)[0];
            //            newCode = new string(chars);
            //            if (ascii != 48)
            //            {
            //                break;
            //            }
            //        }


            //        HS_ShortCode sc = new HS_ShortCode();
            //        sc.AddTime = DateTime.Now;
            //        sc.Code = newCode;
            //        sc.Data = "";
            //        sc.ID = 0;
            //        ll.AddLast(sc);
            //        redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.ShortCodeKey), ll);

            //        var lll = redisClient.Get<LinkedList<HS_ShortCode>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.ShortCodeKey));
            //    }
            //}
            using (var redisClient = RedisManager.GetClient())
            {
                //redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.ShortCodeKey), new LinkedList<HS_ShortCode>());
                //var llll = redisClient.Get<LinkedList<HS_ShortCode>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.ShortCodeKey)).ToList();
                //var str = redisClient.Get<string>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.Test));
                //var sdsadas = redisClient.Get<LinkedList<HS_ShortCode>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.ShortCodeKey));
                //for (int n = 0; n < llll.Count; n++)
                //{
                //    Log.Default.Debug(llll[n].Code);
                //}
            }
            //string code = "00000";
            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            //for (int i = 0; i < 10000000; i++)
            //{
            //    code = ShortCodeBll.Instance.CreateNextCode(code);
            //}
            //watch.Stop();
            //Console.WriteLine(watch.ElapsedMilliseconds);
            //watch.Restart();
            ////code = "00000";
            //for (int i = 0; i < 10000000; i++)
            //{
            //    RandomUtil.CreateRandomStr(5);
            //}
            //watch.Stop();
            //Console.WriteLine(watch.ElapsedMilliseconds);
            var user = UsersBll.Instance.GetById(1);
            //string code = ShortCodeBll.Instance.CreateCode("玛尼玛尼红");
            Console.ReadKey();
        }
    }
}
