using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Servant
{
    public class AllEnemyServantFilter : IServantFilter
    {
        public Func<Card, bool> Filter(BaseActionParameter actionParameter)
        {
            UserContext user = null;
            if (actionParameter.SecondaryCard != null)
                user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.SecondaryCard);
            else
                user = actionParameter.GameContext.GetEnemyUserContextByMyCard(actionParameter.MainCard);
            return new Func<Card, bool>(c => c != null && c.CardType == CardType.随从 && c.IsFirstPlayerCard == user.IsFirst);
        }
    }
}
