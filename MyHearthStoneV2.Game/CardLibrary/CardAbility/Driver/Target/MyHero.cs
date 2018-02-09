using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Target
{
    internal class MyHero : ITarget
    {
        public Func<BaseBiology, bool> Filter(BaseActionParameter actionParameter)
        {
            UserContext user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.SecondaryCard);
            return new Func<BaseBiology, bool>(c => c != null && c.CardType == CardType.英雄 && c.DeskIndex == (user.IsFirst ? 0 : 8));
        }
    }
}
