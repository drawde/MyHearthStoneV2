using MyHearthStoneV2.Game.CardLibrary;
using MyHearthStoneV2.Game.Parameter;
using System;

namespace MyHearthStoneV2.Game.Widget.Filter.ParameterFilter
{
    /// <summary>
    /// 目标筛选器
    /// </summary>
    public interface IParameterFilter
    {
        Func<Card, bool> Filter(BaseActionParameter actionParameter);        
    }
}
