using BattleForAzeroth.Game.Parameter;
using BattleForAzeroth.Game.Widget.Number;

namespace BattleForAzeroth.Game.Widget.Condition.Assert.Number.More
{
    public class MoreThan<NumOne, NumTwo> : IAssert where NumOne : INumber where NumTwo : INumber
    {
        public bool True(ActionParameter actionParameter)
        {
            NumOne one = GameActivator<NumOne>.CreateInstance();
            NumTwo two = GameActivator<NumTwo>.CreateInstance();
            return one.GetNumber(actionParameter) > two.GetNumber(actionParameter);
        }
    }
}
