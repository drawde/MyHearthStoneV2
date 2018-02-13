using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game.Parameter;
using System;
using MyHearthStoneV2.Game.Context;
namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter
{
    internal class AllSecondaryRandomBiologyFilter : IFilter
    {
        public Func<Card, bool> Filter(BaseActionParameter actionParameter)
        {
            var targets = actionParameter.GameContext.DeskCards.GetDeskCardsByIsFirst(actionParameter.GameContext.GetUserContextByMyCard(actionParameter.SecondaryCard).IsFirst);
            return new Func<Card, bool>(c => c != null && c.CardInGameCode == targets[RandomUtil.CreateRandomInt(0, targets.Count - 1)].CardInGameCode);
        }
    }
}
