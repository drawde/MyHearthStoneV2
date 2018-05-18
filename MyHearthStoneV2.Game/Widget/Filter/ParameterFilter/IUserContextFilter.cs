using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System;
using MyHearthStoneV2.Game.CardLibrary;
namespace MyHearthStoneV2.Game.Widget.Filter.ParameterFilter
{
    public interface IUserContextFilter : IGameCache
    {
        Func<UserContext, bool> Filter(BaseActionParameter actionParameter);
    }
}
