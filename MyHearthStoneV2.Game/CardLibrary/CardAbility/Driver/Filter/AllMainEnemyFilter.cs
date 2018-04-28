using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter
{
    public class AllMainEnemyFilter : IFilter
    {
        public bool NoCache { get; set; } = true;
        public Func<Card, bool> Filter(BaseActionParameter actionParameter)
        {
            UserContext user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
            return new Func<Card, bool>(c => c != null && (c.CardType == CardType.随从 || c.CardType == CardType.英雄) && c.IsFirstPlayerCard == user.IsFirst);
        }
    }
}
