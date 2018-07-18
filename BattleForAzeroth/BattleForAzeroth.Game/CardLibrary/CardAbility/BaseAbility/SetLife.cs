using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using System.Linq;
using BattleForAzeroth.Game.Widget.Number;
using BattleForAzeroth.Game.Widget.Filter.Servant;
using System;
using BattleForAzeroth.Game.Widget.Filter.CardLocationFilter;

namespace BattleForAzeroth.Game.CardLibrary.CardAbility.BaseAbility
{
    public class SetLife<UC, CardLocation, F, NUM> : ICardAbility where UC : IUserContextFilter where F : IServantCardFilter where NUM : INumber where CardLocation : ICardLocationFilter
    {
        public IActionOutputParameter Action(ActionParameter actionParameter)
        {
            UC uc = GameActivator<UC>.CreateInstance();
            var users = actionParameter.GameContext.Players.Where(uc.Filter(actionParameter));
            var filter = Activator.CreateInstance<F>();
            CardLocation cardLocation = GameActivator<CardLocation>.CreateInstance();

            int num = GameActivator<NUM>.CreateInstance().GetNumber(actionParameter);
            foreach (UserContext user in users)
            {
                foreach (Card card in user.AllCards.Where(c=>c.CardType == CardType.英雄 || c.CardType == CardType.随从).Where(x => cardLocation.Filter(x)).Where(filter.Filter(actionParameter)))
                {
                    BaseBiology baseBiology = card as BaseBiology;
                    baseBiology.Life = num;
                    baseBiology.BuffLife = num;
                }
            }
            return null;
        }

        public bool TryCapture(Card card, Event.IEvent @event) => false;
    }
}
