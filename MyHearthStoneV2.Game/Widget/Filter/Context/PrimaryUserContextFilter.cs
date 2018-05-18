using System;
using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Widget.Filter.ParameterFilter;

namespace MyHearthStoneV2.Game.Widget.Filter.Context
{
    public class PrimaryUserContextFilter : IUserContextFilter
    {
        public bool NoCache { get; set; } = true;
        public Func<UserContext, bool> Filter(BaseActionParameter actionParameter)
        {
            UserContext user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.PrimaryCard);
            return new Func<UserContext, bool>(c => c.IsFirst == user.IsFirst);
        }
    }
}
