using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System;
using MyHearthStoneV2.Game.CardLibrary;
namespace MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Servant
{
    public class AllEnemyServantFilter : IServantFilter
    {
        public Func<Card, bool> Filter(BaseActionParameter actionParameter)
        {
            UserContext user = null;
            if (actionParameter.SecondaryCard != null)
                user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.SecondaryCard);
            else
                user = actionParameter.GameContext.GetEnemyUserContextByMyCard(actionParameter.PrimaryCard);
            return new Func<Card, bool>(c => c != null && c.CardType == CardType.随从 && c.IsFirstPlayerCard == user.IsFirst);
        }
    }
}
