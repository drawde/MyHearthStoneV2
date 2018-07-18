using BattleForAzeroth.Game.Context;
using BattleForAzeroth.Game.Parameter;
using System;
using BattleForAzeroth.Game.CardLibrary;
namespace BattleForAzeroth.Game.Widget.Filter.ParameterFilter
{
    public interface IUserContextFilter : IGameWidgetCache
    {
        Func<UserContext, bool> Filter(ActionParameter actionParameter);
    }
}
