using BattleForAzeroth.Game.Parameter;

namespace BattleForAzeroth.Game.Widget.Condition.Assert
{
    public interface IAssert
    {
        bool True(ActionParameter actionParameter);
    }
}
