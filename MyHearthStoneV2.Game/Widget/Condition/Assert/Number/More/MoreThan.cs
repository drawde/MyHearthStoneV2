using MyHearthStoneV2.Game.Parameter;
using MyHearthStoneV2.Game.Widget.Number;

namespace MyHearthStoneV2.Game.Widget.Condition.Assert.Number.More
{
    public class MoreThan<NumOne, NumTwo> : IAssert where NumOne : INumber where NumTwo : INumber
    {
        public bool True(BaseActionParameter actionParameter)
        {
            NumOne one = GameActivator<NumOne>.CreateInstance();
            NumTwo two = GameActivator<NumTwo>.CreateInstance();
            return one.GetNumber(actionParameter) > two.GetNumber(actionParameter);
        }
    }
}
