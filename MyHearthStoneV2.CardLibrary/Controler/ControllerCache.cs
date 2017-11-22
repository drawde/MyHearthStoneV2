using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyHearthStoneV2.CardLibrary.Controler
{
    public class ControllerCache
    {
        public static List<Controler_Base> GetControls()
        {
            using (var redisClient = RedisManager.GetClient())
            {
                var lst = redisClient.Get<List<Controler_Base>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameControllers));
                if (lst == null)
                {
                    lst = new List<Controler_Base>();
                    redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameControllers), lst);
                }
                return lst;
            }
        }
        public static Controler_Base GetControler(string gameCode)
        {
            var lstCtls = GetControls();
            if (lstCtls.Any(c => c.GameCode == gameCode))
            {
                return lstCtls[lstCtls.FindIndex(c => c.GameCode == gameCode)];
            }
            return null;
        }
        public static void Init()
        {
            if (GetControls() == null)
            {
                using (var redisClient = RedisManager.GetClient())
                {
                    redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameControllers), new List<Controler_Base>());
                }
            }
        }

        public static void SetController(Controler_Base ctl)
        {
            var lstCtls = GetControls();
            if (lstCtls.Any(c => c.GameCode == ctl.GameCode))
            {
                lstCtls[lstCtls.FindIndex(c => c.GameCode == ctl.GameCode)] = ctl;
            }
            else
            {
                lstCtls.Add(ctl);
            }
            using (var redisClient = RedisManager.GetClient())
            {
                redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameControllers), lstCtls);
            }
        }

        
    }
}
