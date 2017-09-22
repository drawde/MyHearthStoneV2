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
        public static List<Controler> LstCtl
        {
            get
            {
                using (var redisClient = RedisManager.GetClient())
                {
                    var lst = redisClient.Get<List<Controler>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameControllers));
                    if (lst == null)
                    {
                        lst = new List<Controler>();
                        redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameControllers), lst);
                    }
                    return lst;
                }
            }
            set
            {
                using (var redisClient = RedisManager.GetClient())
                {
                    redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameControllers), value);
                }
            }
        }


        public static void SetController(Controler ctl)
        {
            LstCtl[LstCtl.FindIndex(c=>c.GameID == ctl.GameID)] = ctl;
        }
    }
}
