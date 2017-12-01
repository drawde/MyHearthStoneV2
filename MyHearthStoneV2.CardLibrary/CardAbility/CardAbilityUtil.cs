using MyHearthStoneV2.CardLibrary.Base;
using MyHearthStoneV2.CardLibrary.Context;
using MyHearthStoneV2.CardLibrary.Controler;
using MyHearthStoneV2.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.CardLibrary.CardAbility
{
    /// <summary>
    /// 卡牌技能帮助类
    /// </summary>
    public static class CardAbilityUtil
    {
        /// <summary>
        /// 创造一张牌到场内
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controler"></param>
        /// <param name="isActivation">是否是当前回合玩家的牌</param>
        /// <returns></returns>
        public static T CreateNewCardInDesk<T>(this GameContext context, bool isActivation = true) where T : Card
        {
            T card = Activator.CreateInstance<T>();
            string cardCode = "";
            using (var redisClient = RedisManager.GetClient())
            {
                List<Card> lstCardLib = redisClient.Get<List<Card>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CardsInstance));
                cardCode = lstCardLib.First(c => c.GetType() == typeof(T)).CardCode;
            }
            card.CardCode = cardCode;
            card.CardInGameCode = context.AllCard.Count.ToString();
            var player = context.Players.First(c => c.IsActivation == isActivation);
            player.DeskCards[player.DeskCards.FindIndex(c => c is null)] = card;
            player.AllCards.Add(card);
            context.AllCard.Add(card);
            return card;
        }

        /// <summary>
        /// 获取当前回合玩家
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static UserContext GetActivationUserContext(this GameContext context)
        {
            return context.Players.First(c => c.IsActivation);
        }

        /// <summary>
        /// 获取不是当前回合的玩家
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static UserContext GetNotActivationUserContext(this GameContext context)
        {
            return context.Players.First(c => c.IsActivation == false);
        }

        /// <summary>
        /// 判断这张牌是否是当前回合玩家打出的牌
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static bool IsThisActivationUserCard(this GameContext context, Card card)
        {
            return context.Players.Any(c => c.IsActivation && c.AllCards.Any(x => x.CardInGameCode == card.CardInGameCode));
        }

        /// <summary>
        /// 根据下标获取场上的牌
        /// </summary>
        /// <param name="context"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public static Card GetCardByLocation(this GameContext context, int location)
        {
            return context.Players.First(c => c.IsFirst == location < 8).DeskCards[location];
        }
    }
}
