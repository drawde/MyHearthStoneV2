using BattleForAzeroth.Game.CardLibrary.CardAction.Controler;
using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.CardLibrary.Servant;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using System.Linq;
using System.Collections.Generic;
using System;
using BattleForAzeroth.Game.Widget.Filter.PickCard;
using BattleForAzeroth.Game.Widget.Filter.Servant;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    public class Resurrection<UC, F, CardPick> : ICardAbility where UC : IUserContextFilter where F : IServantCardFilter where CardPick : ICardPickFilter
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            UC uc = GameActivator<UC>.CreateInstance();
            var users = actionParameter.GameContext.Players.Where(uc.Filter(actionParameter));
            var filter = Activator.CreateInstance<F>();
            CardPick cardPick = Activator.CreateInstance<CardPick>();
            List<BaseServant> servants = new List<BaseServant>();
            List<Card> lstCardLib = actionParameter.GameContext.GameCache.GetAllCard();

            foreach (UserContext user in users)
            {
                List<Card> deadCards = user.GraveyardCards.Where(filter.Filter(actionParameter)).ToList();
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
                    //if (user.GraveyardCards.Any(c => c.CardCode == card.CardCode))
                    //{
                    //    user.GraveyardCards.RemoveAt(user.GraveyardCards.FindIndex(c => c.CardCode == card.CardCode));
                    //}
                    CreateNewCardInDeskAction action = new CreateNewCardInDeskAction();
                    var para = new ActionParameter()
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
