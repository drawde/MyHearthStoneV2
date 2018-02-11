using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Target.Context
{
    internal class SecondaryUserContextFilter : IUserContextFilter
    {
        public Func<UserContext, bool> Filter(BaseActionParameter actionParameter)
        {
            UserContext user = actionParameter.GameContext.GetUserContextByMyCard(actionParameter.SecondaryCard);
            return new Func<UserContext, bool>(c => c.IsFirst = user.IsFirst);
        }
    }
}
