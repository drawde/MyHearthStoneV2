﻿using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game.Parameter;
using System;
using MyHearthStoneV2.Game.Context;
using System.Linq;
namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter
{
    public class AllSecondaryRandomBiologyFilter : IFilter
    {
        public bool NoCache { get; set; } = true;
        public Func<Card, bool> Filter(BaseActionParameter actionParameter)
        {
            var targets = actionParameter.GameContext.DeskCards.GetDeskCardsByIsFirst(actionParameter.GameContext.GetUserContextByMyCard(actionParameter.SecondaryCard).IsFirst).
                Where(c => c != null).ToList();
            return new Func<Card, bool>(c => c != null && c.CardInGameCode == targets[RandomUtil.CreateRandomInt(0, targets.Count - 1)].CardInGameCode);
        }
    }
}
