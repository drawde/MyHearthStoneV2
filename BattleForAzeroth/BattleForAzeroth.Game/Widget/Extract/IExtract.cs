using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Widget.Filter.ParameterFilter;

namespace BattleForAzeroth.Game.Widget.Extract
{
    public interface IExtract<F> where F : IParameterFilter
    {
        string Extract(ActionParameter actionParameter);
    }
}
