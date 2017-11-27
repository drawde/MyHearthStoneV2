using MyHearthStoneV2.CardEnum;
using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.Model;
using MyHearthStoneV2.Redis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHearthStoneV2.CardLibrary.Controler
{
    public partial class Controler_Base
    {
        /// <summary>
        /// 获取当前回合的用户对象
        /// </summary>
        /// <returns></returns>
        public UserContext GetCurrentTurnUserCards()
        {
            return gameContext.Players.First(c => c.IsActivation);
        }

        /// <summary>
        /// 获取下个回合或是后手的用户对象
        /// </summary>
        /// <returns></returns>
        public UserContext GetNextTurnUserCards()
        {
            return gameContext.Players.First(c => c.IsActivation == false || c.IsFirst == false);
        }

        /// <summary>
        /// 创造一张牌到游戏中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T CreateNewCardInController<T>() where T : Card
        {
            T card = Activator.CreateInstance<T>();
            string cardCode = "";
            using (var redisClient = RedisManager.GetClient())
            {
                List<Card> lstCardLib = redisClient.Get<List<Card>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CardsInstance));
                cardCode = lstCardLib.First(c => c.GetType() == typeof(T)).CardCode;
            }
            card.CardCode = cardCode;
            card.CardInGameCode = gameContext.AllCard.Count.ToString();
            return card;
        }
        //public void TryTriggerCardAbility(Card card, SpellCardAbilityTime spellCardAbilityTime)
        //{

        //}
    }
}
