using MyHearthStoneV2.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.Context
{
    internal class GameContextCache
    {
        internal static List<GameContext> GetContexts()
        {
            using (var redisClient = RedisManager.GetClient())
            {
                var lst = redisClient.Get<List<GameContext>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext));
                if (lst == null)
                {
                    lst = new List<GameContext>();
                    redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext), lst);
                }
                return lst;
            }
        }
        internal static GameContext GetContext(string gameCode)
        {
            var lstCtls = GetContexts();
            if (lstCtls.Any(c => c.GameCode == gameCode))
            {
                return lstCtls[lstCtls.FindIndex(c => c.GameCode == gameCode)];
            }
            return null;
        }
        internal static void Init()
        {
            if (GetContexts() == null)
            {
                using (var redisClient = RedisManager.GetClient())
                {
                    redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext), new List<GameContext>());
                }
            }
        }

        internal static void SetContext(GameContext ctl)
        {
            var lstCtls = GetContexts();
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
                redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext), lstCtls);
            }
        }
    }
}
