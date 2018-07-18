using BattleForAzeroth.Game.CardLibrary.CardAction.Controler;
using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using System.Linq;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.Servant;
using System.Collections.Generic;
using System;
using BattleForAzeroth.Game.Widget.Filter.PickCard;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    /// <summary>
    /// 召唤一个随从到场上
    /// </summary>
    /// <typeparam name="F"></typeparam>
    public class Summon<UC, CardLocation, F, CardPick, NUM> : ICardAbility where UC : IUserContextFilter where F : IServantCardFilter where CardPick : ICardPickFilter where NUM : INumber where CardLocation : ICardLocationFilter
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            UC uc = GameActivator<UC>.CreateInstance();
            var users = actionParameter.GameContext.Players.Where(uc.Filter(actionParameter));
            var filter = Activator.CreateInstance<F>();
            CardLocation cardLocation = GameActivator<CardLocation>.CreateInstance();
            List<Card> summonCards = new List<Card>();
            CardPick cardPick = Activator.CreateInstance<CardPick>();
            summonCards.AddRange(actionParameter.GameContext.GameCache.GetAllCard().Where(filter.Filter(actionParameter)));

            NUM num = GameActivator<NUM>.CreateInstance();
            foreach (UserContext user in users)
            {
                summonCards = cardPick.Filter(summonCards.Where(c => user.AllCards.Where(x => cardLocation.Filter(x)).Any(z => z.CardCode == c.CardCode)).ToList(), actionParameter).ToList();
                foreach (Card card in summonCards)
                {
                    for (int i = 0; i < num.GetNumber(actionParameter); i++)
                    {
                        var newCard = Activator.CreateInstance(card.GetType()) as Card;
                        newCard.CardCode = card.CardCode;
                        CreateNewCardInDeskAction action = new CreateNewCardInDeskAction();
                        var para = new ActionParameter()
                        {
                            GameContext = actionParameter.GameContext,
                            IsActivation = user.IsActivation,
                            PrimaryCard = newCard
                        };
                        action.Action(para);
                    }
                }
            }
            return null;
        }

        public bool TryCapture(Card card, Event.IEvent @event) => false;
    }
}
