using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Context
{
    public class SecondaryUserContextFilter : IUserContextFilter
    {
        public Func<UserContext, bool> Filter(BaseActionParameter actionParameter)
        {
            UserContext user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.SecondaryCard);
            return new Func<UserContext, bool>(c => c.IsFirst == user.IsFirst);
        }
    }
}
