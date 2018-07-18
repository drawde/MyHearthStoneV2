using BattleForAzeroth.Game.CardLibrary;
using BattleForAzeroth.Game.Parameter;
using System;

namespace BattleForAzeroth.Game.Widget.Filter.ParameterFilter
{
    /// <summary>
    /// 目标筛选器
    /// </summary>
    public interface IParameterFilter
    {
        Func<Card, bool> Filter(ActionParameter actionParameter);        
    }
}
