using MyHearthStoneV2.Common.Enum;
using MyHearthStoneV2.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.GameControler
{
    public class ControllerCache
    {
        public static List<Controler> GetController()
        {
            using (var redisClient = RedisManager.GetClient())
            {
                return redisClient.Get<List<Controler>>(RedisKeyEnum.GameControllers.ToString());
            }
        }

        public static void InitController()
        {
            using (var redisClient = RedisManager.GetClient())
            {
                redisClient.Set(RedisKeyEnum.GameControllers.ToString(), new List<Controler>());
            }
        }

        public static void SetController(Controler ctl)
        {
            using (var redisClient = RedisManager.GetClient())
            {
                var lst = GetController();
                lst.Add(ctl);
                redisClient.Set(RedisKeyEnum.GameControllers.ToString(), lst);
            }
        }
    }
}
