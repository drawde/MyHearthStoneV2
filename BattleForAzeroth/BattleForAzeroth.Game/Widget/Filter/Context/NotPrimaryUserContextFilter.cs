using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;
using System;
namespace BattleForAzeroth.Game.Widget.Filter.Context
{
    public class NotPrimaryUserContextFilter : IUserContextFilter
    {
        public bool NoCache { get; set; } = true;
        public Func<UserContext, bool> Filter(ActionParameter actionParameter)
        {
            UserContext user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.PrimaryCard);
            return new Func<UserContext, bool>(c => c.IsFirst != user.IsFirst);
        }
    }
}
