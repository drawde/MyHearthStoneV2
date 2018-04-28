using MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Number;
using MyHearthStoneV2.Game.Parameter;

namespace MyHearthStoneV2.Game.CardLibrary.Filter.Condition.Assert.Number.More
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
