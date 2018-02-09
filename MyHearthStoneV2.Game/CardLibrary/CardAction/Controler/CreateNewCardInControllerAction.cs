﻿using MyHearthStoneV2.Game.Action;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Controler;
using MyHearthStoneV2.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAction.Controler
{
    /// <summary>
    /// 创建一张牌
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class CreateNewCardInControllerAction<T> : Action.IGameAction where T : Card
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            ControlerActionParameter para = actionParameter as ControlerActionParameter;
            GameContext context = para.GameContext;
            UserContext userContext = para.UserContext;
            T card = Activator.CreateInstance<T>();
            string cardCode = "";
            using (var redisClient = RedisManager.GetClient())
            {
                List<Card> lstCardLib = redisClient.Get<List<Card>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CardsInstance));
                cardCode = lstCardLib.First(c => c.GetType() == typeof(T)).CardCode;
            }
            card.CardCode = cardCode;
            context.AllCard.Add(card);
            card.CardInGameCode = context.AllCard.Count.ToString();
            context.Players.First(c => c == userContext).AllCards.Add(card);
            return card;
        }
    }
}
