using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;
using System;
using BattleForAzeroth.Game.CardLibrary;
namespace BattleForAzeroth.Game.Widget.Filter.ParameterFilter.Servant
{
    public class AllPrimaryServantFilter : IServantFilter
    {
        public Func<Card, bool> Filter(ActionParameter actionParameter)
        {
            UserContext user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.PrimaryCard);
            return new Func<Card, bool>(c => c != null && c.CardType == CardType.随从 && c.IsFirstPlayerCard == user.IsFirst 
            && (c.CardLocation == CardLocation.场上 || c.CardLocation == CardLocation.手牌 || c.CardLocation == CardLocation.牌库));
        }
    }
}
