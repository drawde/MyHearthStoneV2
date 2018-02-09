using MyHearthStoneV2.Game.Context;
using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.CardLibrary.CardAbility.Driver
{
    /// <summary>
    /// 目标筛选器
    /// </summary>
    internal interface ITarget: IGameCache
    {
        Func<BaseBiology, bool> Filter(BaseActionParameter actionParameter);        
    }
}
