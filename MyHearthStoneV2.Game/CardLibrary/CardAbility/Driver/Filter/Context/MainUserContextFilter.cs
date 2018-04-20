using System;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Filter.Context
{
    public class MainUserContextFilter : IUserContextFilter
    {
        public Func<UserContext, bool> Filter(BaseActionParameter actionParameter)
        {
            UserContext user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.MainCard);
            return new Func<UserContext, bool>(c => c.IsFirst == user.IsFirst);
        }
    }
}
