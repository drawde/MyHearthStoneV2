using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MyHearthStoneV2.Game.CardLibrary.Filter.Servant
{
    public class RandomServantOfCostFilter<Q> : IServantCardFilter where Q : INumber
    {
        public Func<Card, bool> Filter()
        {
            Q qat = GameActivator<Q>.CreateInstance();
            List<Card> lstCardLib;
            using (var redisClient = RedisManager.GetClient())
            {
                lstCardLib = redisClient.Get<List<Card>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CardsInstance));
            }
            List<Card> servants = lstCardLib.Where(c => c.Cost == qat.Number && c.CardType == CardType.随从 && c.Profession == Profession.Neutral && c.IsDerivative == false).ToList();
            BaseServant servant = servants[RandomUtil.CreateRandomInt(0, servants.Count - 1)] as BaseServant;
            return new Func<Card, bool>(c => c.CardCode == servant.CardCode);
        }
    }
}
