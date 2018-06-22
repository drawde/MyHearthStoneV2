using MyHearthStoneV2.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.Context
{
    public class GameContextCache
    {
        public static GameContext GetContext(string gameCode)
        {
            using (var redisClient = RedisManager.GetClient())
            {
                try
                {
                    redisClient.Watch(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext, gameCode));
                    return redisClient.Get<GameContext>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext, gameCode));
                }
                finally
                {
                    redisClient.UnWatch();
                }
            }
        }

        public static void SetContext(GameContext gameContext)
        {
            using (var redisClient = RedisManager.GetClient())
            {
                try
                {
                    redisClient.Watch(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext, gameContext.GameCode));
                    redisClient.Set(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext, gameContext.GameCode), gameContext);                    
                }
                finally
                {
                    redisClient.UnWatch();
                }
            }
        }

        public static void RemoveContext(GameContext ctl)
        {
            using (var redisClient = RedisManager.GetClient())
            {
                try
                {
                    redisClient.Watch(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext, ctl.GameCode));
                    redisClient.Remove(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.GameContext, ctl.GameCode));
                }
                finally
                {
                    redisClient.UnWatch();
                }
            }
        }
    }
}
