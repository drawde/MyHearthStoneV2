using MyHearthStoneV2.Game.CardLibrary.CardAction.Controler;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Parameter.Controler;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;
using System.Linq;
using MyHearthStoneV2.Game.Widget.Number;
using MyHearthStoneV2.Game.Widget.Filter.Servant;
using MyHearthStoneV2.Redis;
using System.Collections.Generic;
using System;
using MyHearthStoneV2.Game.Widget.Filter.PickCard;
using MyHearthStoneV2.Game.Widget.Filter.CardLocationFilter;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.BaseAbility
{
    public class SetLife<UC, CardLocation, F, NUM> : ICardAbility where UC : IUserContextFilter where F : IServantCardFilter where NUM : INumber where CardLocation : ICardLocationFilter
    {
        public IActionOutputParameter Action(BaseActionParameter actionParameter)
        {
            UC uc = GameActivator<UC>.CreateInstance();
            var users = actionParameter.GameContext.Players.Where(uc.Filter(actionParameter));
            var filter = Activator.CreateInstance<F>();
            CardLocation cardLocation = GameActivator<CardLocation>.CreateInstance();

            int num = GameActivator<NUM>.CreateInstance().GetNumber(actionParameter);
            foreach (UserContext user in users)
            {
                foreach (Card card in user.AllCards.Where(c=>c.CardType == CardType.英雄 || c.CardType == CardType.随从).Where(x => cardLocation.Filter(x)).Where(filter.Filter()))
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
