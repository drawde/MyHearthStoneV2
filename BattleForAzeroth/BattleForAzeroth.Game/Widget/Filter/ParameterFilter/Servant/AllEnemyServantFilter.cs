using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;
using System;
using BattleForAzeroth.Game.CardLibrary;
namespace BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant
{
    public class AllEnemyServantFilter : IServantFilter
    {
        public Func<Card, bool> Filter(ActionParameter actionParameter)
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
