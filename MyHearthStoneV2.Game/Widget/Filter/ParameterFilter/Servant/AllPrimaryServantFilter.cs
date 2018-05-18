using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System;
using MyHearthStoneV2.Game.CardLibrary;
namespace MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Servant
{
    public class AllPrimaryServantFilter : IServantFilter
    {
        public Func<Card, bool> Filter(BaseActionParameter actionParameter)
        {
            UserContext user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.PrimaryCard);
            return new Func<Card, bool>(c => c != null && c.CardType == CardType.随从 && c.IsFirstPlayerCard == user.IsFirst 
            && (c.CardLocation == CardLocation.场上 || c.CardLocation == CardLocation.手牌 || c.CardLocation == CardLocation.牌库));
        }
    }
}
