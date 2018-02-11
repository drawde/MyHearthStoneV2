﻿using MyHearthStoneV2.Game.CardLibrary.Hero;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Target.Hero
{
    internal class MainHeroTarget : IHeroTarget
    {
        public Func<Card, bool> Filter(BaseActionParameter actionParameter)
        {
            UserContext user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
            return new Func<Card, bool>(c => c != null && c.CardType == CardType.英雄 && (c as BaseHero).DeskIndex == (user.IsFirst ? 0 : 8));
        }
    }
}
