using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Hero
{
    internal class SecondaryHeroFilter : IHeroFilter
    {
        public Func<Card, bool> Filter(BaseActionParameter actionParameter)
        {
            UserContext user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.SecondaryCard);
            return new Func<Card, bool>(c => c != null && c.CardType == CardType.英雄 && (c as BaseHero).DeskIndex == (user.IsFirst ? 0 : 8));
        }
    }
}
