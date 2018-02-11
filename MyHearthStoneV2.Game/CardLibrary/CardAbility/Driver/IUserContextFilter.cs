﻿using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver.Target
{
    internal interface IUserContextFilter : IGameCache
    {
        Func<UserContext, bool> Filter(BaseActionParameter actionParameter);
    }
}
