﻿using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 目标筛选器(针对场上的牌)
    /// </summary>
    public interface IFilter
    {
        Func<Card, bool> Filter(BaseActionParameter actionParameter);        
    }
}
