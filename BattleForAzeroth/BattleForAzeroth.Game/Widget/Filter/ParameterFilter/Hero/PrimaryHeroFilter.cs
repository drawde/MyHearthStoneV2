using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.CardLibrary.Hero;
using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;
using System;

namespace BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Hero
{
    public class PrimaryHeroFilter : IHeroFilter
    {
        public Func<Card, bool> Filter(ActionParameter actionParameter)
        {
            UserContext user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.PrimaryCard);
            return new Func<Card, bool>(c => c != null && c.CardType == CardType.英雄 && (c as BaseHero).DeskIndex == (user.IsFirst ? 0 : 8));
        }
    }
}
