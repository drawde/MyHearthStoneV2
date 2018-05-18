using MyHearthStoneV2.Common.Util;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System;
using MyHearthStoneV2.Game.CardLibrary;
namespace MyHearthStoneV2.Game.Widget.Filter.ParameterFilter.Servant
{
    public class NotPrimaryRandomServantFilter : IServantFilter
    {
        public Func<Card, bool> Filter(BaseActionParameter actionParameter)
        {
            UserContext user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.PrimaryCard);
            var targets = actionParameter.GameContext.DeskCards.GetDeskServantsByIsFirst(user.IsFirst ? false : true);
            return new Func<Card, bool>(c => c.CardInGameCode == targets[RandomUtil.CreateRandomInt(0, targets.Count - 1)].CardInGameCode);
        }
    }
}
