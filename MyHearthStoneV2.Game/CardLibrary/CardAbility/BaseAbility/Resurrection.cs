using MyHearthStoneV2.Game.CardLibrary.CardAction.Controler;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Controler;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.CardLibrary.Servant;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using System.Linq;
using MyHearthStoneV2.Redis;
using System.Collections.Generic;
using System;
using MyHearthStoneV2.Game.Widget.Filter.PickCard;
using MyHearthStoneV2.Game.Widget.Filter.Servant;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    public class Resurrection<UC, F, CardPick> : ICardAbility where UC : IUserContextFilter where F : IServantCardFilter where CardPick : ICardPickFilter
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            UC uc = GameActivator<UC>.CreateInstance();
            var users = actionParameter.GameContext.Players.Where(uc.Filter(actionParameter));
            var filter = Activator.CreateInstance<F>();
            CardPick cardPick = Activator.CreateInstance<CardPick>();
            List<BaseServant> servants = new List<BaseServant>();
            List<Card> lstCardLib = new List<Card>();
            using (var redisClient = RedisManager.GetClient())
            {
                lstCardLib = redisClient.Get<List<Card>>(RedisKey.GetKey(RedisAppKeyEnum.Alpha, RedisCategoryKeyEnum.CardsInstance));
            }

            foreach (UserContext user in users)
            {
                List<Card> deadCards = user.GraveyardCards.Where(filter.Filter()).ToList();
                List<Card> waitingCards = new List<Card>();
                foreach (Card card in deadCards)
                {
                    Card libCard = lstCardLib.First(c => c.CardCode == card.CardCode);
                    var newCard = Activator.CreateInstance(libCard.GetType()) as Card;
                    newCard.CardCode = libCard.CardCode;
                    waitingCards.Add(newCard);
                }
                var resurrectionCards = cardPick.Filter(waitingCards, actionParameter);
                foreach (var card in resurrectionCards)
                {
                    if (user.GraveyardCards.Any(c => c.CardCode == card.CardCode))
                    {
                        user.GraveyardCards.RemoveAt(user.GraveyardCards.FindIndex(c => c.CardCode == card.CardCode));
                    }
                    CreateNewCardInDeskAction action = new CreateNewCardInDeskAction();
                    ControlerActionParameter para = new ControlerActionParameter()
                    {
                        GameContext = actionParameter.GameContext,
                        IsActivation = user.IsActivation,
                        PrimaryCard = card
                    };
                    action.Action(para);
                }
            }
            return null;
        }

        public bool TryCapture(Card card, Event.IEvent @event) => false;
    }
}
