using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Controler;
using MyHearthStoneV2.Redis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Controler
{
    /// <summary>
    /// 创造一张牌到手牌
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CreateNewGenericCardInHandAction<T> : Action.IGameAction where T : Card
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            //ControlerActionParameter para = actionParameter as ControlerActionParameter;
            GameContext context = actionParameter.GameContext;
            UserContext userContext = actionParameter.UserContext;
            T card = Activator.CreateInstance<T>();
            string cardCode = "";
            using (var redisClient = RedisManager.GetClient())
            {
                List<Card> lstCardLib = redisClient.Get<List<Card>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CardsInstance));
                cardCode = lstCardLib.First(c => c.GetType() == typeof(T)).CardCode;
            }
            card.IsFirstPlayerCard = userContext.IsFirst;
            card.CardCode = cardCode;
            context.AllCard.Add(card);
            card.CardInGameCode = context.AllCard.Count.ToString();
            context.Players.First(c => c == userContext).AllCards.Add(card);

            if (userContext.HandCards.Count < 10)
            {
                //如果手牌没满则放入手牌中
                userContext.HandCards.Add(card);
                card.CardLocation = CardLocation.手牌;
            }
            else
            {
                //否则撕了这张牌
                card.CardLocation = CardLocation.坟场;
                userContext.GraveyardCards.Add(card);
            }
            return card;
        }
    }
}
